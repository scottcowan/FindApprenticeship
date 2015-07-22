﻿namespace SFA.Apprenticeships.Infrastructure.Processes.Applications
{
    using System;
    using System.Threading.Tasks;
    using Application.Candidate;
    using Application.Interfaces.Applications;
    using Application.Interfaces.Logging;
    using Domain.Entities.Applications;
    using Domain.Entities.Exceptions;
    using Domain.Entities.Users;
    using Domain.Interfaces.Messaging;
    using Domain.Interfaces.Repositories;
    using EasyNetQ.AutoSubscribe;

    public class SubmitApprenticeshipApplicationRequestConsumerAsync : IConsumeAsync<SubmitApprenticeshipApplicationRequest>
    {
        private readonly ILogService _logger;
        private readonly ILegacyApplicationProvider _legacyApplicationProvider;
        private readonly ILegacyCandidateProvider _legacyCandidateProvider;
        private readonly IApprenticeshipApplicationReadRepository _apprenticeshipApplicationReadRepository;
        private readonly IApprenticeshipApplicationWriteRepository _apprenticeshipApplicationWriteRepository;
        private readonly ICandidateReadRepository _candidateReadRepository;
        private readonly IUserReadRepository _userReadRepository;
        private readonly IMessageBus _messageBus;

        public SubmitApprenticeshipApplicationRequestConsumerAsync(
            ILegacyApplicationProvider legacyApplicationProvider,
            ILegacyCandidateProvider legacyCandidateProvider,
            IApprenticeshipApplicationReadRepository apprenticeshipApplicationReadRepository,
            IApprenticeshipApplicationWriteRepository apprenticeshipApplicationWriteRepository,
            ICandidateReadRepository candidateReadRepository,
            IUserReadRepository userReadRepository,
            IMessageBus messageBus, ILogService logger)
        {
            _legacyApplicationProvider = legacyApplicationProvider;
            _legacyCandidateProvider = legacyCandidateProvider;
            _apprenticeshipApplicationReadRepository = apprenticeshipApplicationReadRepository;
            _apprenticeshipApplicationWriteRepository = apprenticeshipApplicationWriteRepository;
            _candidateReadRepository = candidateReadRepository;
            _messageBus = messageBus;
            _logger = logger;
            _userReadRepository = userReadRepository;
        }

        // [SubscriptionConfiguration(PrefetchCount = 2)]
        // [AutoSubscriberConsumer(SubscriptionId = "SubmitApprenticeshipApplicationRequestConsumerAsync")]
        public Task Consume(SubmitApprenticeshipApplicationRequest request)
        {
            return Task.Run(() =>
            {
                if (request.ProcessTime.HasValue && request.ProcessTime > DateTime.Now)
                {
                    try
                    {
                        _messageBus.PublishMessage(request);
                        return;
                    }
                    catch
                    {
                        _logger.Error("Failed to re-queue deferred 'Submit Apprenticeship Application' request: {{ 'ApplicationId': '{0}' }}", request.ApplicationId);
                        throw;
                    }
                }
                
                CreateApplication(request);
            });
        }

        private void CreateApplication(SubmitApprenticeshipApplicationRequest request)
        {
            _logger.Debug("Creating traineeship application Id: {0}", request.ApplicationId);

            var applicationDetail = _apprenticeshipApplicationReadRepository.Get(request.ApplicationId, true);

            try
            {
                var candidate = _candidateReadRepository.Get(applicationDetail.CandidateId, true);

                if (candidate.LegacyCandidateId == 0)
                {
                    var user = _userReadRepository.Get(applicationDetail.CandidateId);
                    if (user == null || user.Status == UserStatuses.PendingDeletion)
                    {
                        _logger.Warn(
                            "User with Id: {0} is set as pending deletion. Application with Id: {1} cannot be submitted and will be set to draft. Message will not be requeued",
                            applicationDetail.CandidateId, request.ApplicationId);
                        applicationDetail.RevertStateToDraft();
                        _apprenticeshipApplicationWriteRepository.Save(applicationDetail);
                    }
                    else
                    {
                        _logger.Info(
                            "Candidate with Id: {0} has not been created in the legacy system. Message will be requeued",
                            applicationDetail.CandidateId);
                        Requeue(request);
                    }
                }
                else
                {
                    EnsureApplicationCanBeCreated(applicationDetail);

                    // Update candidate disability status to match the application.
                    candidate.MonitoringInformation.DisabilityStatus = applicationDetail.CandidateInformation.DisabilityStatus;
                    _legacyCandidateProvider.UpdateCandidate(candidate);

                    applicationDetail.LegacyApplicationId = _legacyApplicationProvider.CreateApplication(applicationDetail);
                    SetApplicationStateSubmitted(applicationDetail);
                }
            }
            catch (CustomException ex)
            {
                HandleCustomException(request, ex, applicationDetail);
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Submit apprenticeship application with Id = {0} request async process failed.", request.ApplicationId), ex);
                Requeue(request);
            }
        }

        private void HandleCustomException(SubmitApprenticeshipApplicationRequest request, CustomException ex, ApprenticeshipApplicationDetail apprenticeshipApplication)
        {
            switch (ex.Code)
            {
                case ErrorCodes.ApplicationDuplicatedError:
                    _logger.Info("Apprenticeship application has already been submitted to legacy system: Application Id: \"{0}\"", request.ApplicationId);
                    SetApplicationStateSubmitted(apprenticeshipApplication);
                    break;

                case Application.Interfaces.Candidates.ErrorCodes.CandidateStateError:
                    _logger.Error("Legacy candidate is in an invalid state. Apprenticeship application cannot be processed: Application Id: \"{0}\"", request.ApplicationId);
                    break;

                case Application.Interfaces.Candidates.ErrorCodes.CandidateNotFoundError:
                    //TODO: This can happen when a user requests that their account should be deleted. We need to work out what to do in that case. Probably set the candidate's status to inactive and the application's status to draft
                    _logger.Error("Legacy candidate was not found. Apprenticeship application cannot be processed: Application Id: \"{0}\"", request.ApplicationId);
                    break;

                case Application.Interfaces.Vacancies.ErrorCodes.LegacyVacancyStateError:
                    _logger.Info("Legacy vacancy was in an invalid state. Apprenticeship application cannot be processed: Application Id: \"{0}\"", request.ApplicationId);
                    SetStateExpiredOrWithdrawn(apprenticeshipApplication);
                    break;

                case Domain.Entities.ErrorCodes.EntityStateError:
                    _logger.Error(string.Format("Apprenticeship application is in an invalid state: Application Id: \"{0}\"", request.ApplicationId), ex);
                    break;

                default:
                    _logger.Warn(string.Format("Submit apprenticeship application with Id = {0} request async process failed.", request.ApplicationId), ex);
                    Requeue(request);
                    break;
            }
        }

        private void SetApplicationStateSubmitted(ApprenticeshipApplicationDetail apprenticeshipApplication)
        {
            apprenticeshipApplication.SetStateSubmitted();
            _apprenticeshipApplicationWriteRepository.Save(apprenticeshipApplication);
        }

        private void SetStateExpiredOrWithdrawn(ApprenticeshipApplicationDetail apprenticeshipApplication)
        {
            apprenticeshipApplication.SetStateExpiredOrWithdrawn();
            _apprenticeshipApplicationWriteRepository.Save(apprenticeshipApplication);
        }

        private void Requeue(SubmitApprenticeshipApplicationRequest request)
        {
            request.ProcessTime = request.ProcessTime.HasValue ? DateTime.Now.AddMinutes(5) : DateTime.Now.AddSeconds(30);
            _messageBus.PublishMessage(request);
        }

        private static void EnsureApplicationCanBeCreated(ApprenticeshipApplicationDetail apprenticeshipApplicationDetail)
        {
            apprenticeshipApplicationDetail.AssertState("Create apprenticeship application", ApplicationStatuses.Submitting);
        }
    }
}
