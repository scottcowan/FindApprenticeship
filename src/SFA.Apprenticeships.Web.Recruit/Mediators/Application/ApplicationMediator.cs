﻿namespace SFA.Apprenticeships.Web.Recruit.Mediators.Application
{
    using Apprenticeships.Application.Interfaces;
    using Apprenticeships.Application.Interfaces.Security;
    using Common.Constants;
    using Common.Mediators;
    using Constants;
    using Domain.Entities.Raa.Vacancies;
    using Raa.Common.Constants.ViewModels;
    using Raa.Common.Providers;
    using Raa.Common.Validators.ProviderUser;
    using Raa.Common.Validators.VacancyStatus;
    using Raa.Common.ViewModels.Application;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class ApplicationMediator : MediatorBase, IApplicationMediator
    {
        private readonly IApplicationProvider _applicationProvider;
        private readonly ShareApplicationsViewModelValidator _shareApplicationsViewModelValidator;
        private readonly IEncryptionService<AnonymisedApplicationLink> _encryptionService;
        private readonly IDateTimeService _dateTimeService;
        private readonly BulkDeclineCandidatesViewModelServerValidator _bulkDeclineCandidatesViewModelServerValidator = new BulkDeclineCandidatesViewModelServerValidator();

        public ApplicationMediator(IApplicationProvider applicationProvider,
            ShareApplicationsViewModelValidator shareApplicationsViewModelValidator,
            IEncryptionService<AnonymisedApplicationLink> encryptionService, IDateTimeService dateTimeService)
        {
            _applicationProvider = applicationProvider;
            _shareApplicationsViewModelValidator = shareApplicationsViewModelValidator;
            _encryptionService = encryptionService;
            _dateTimeService = dateTimeService;
        }

        public async Task<MediatorResponse<VacancyApplicationsViewModel>> GetVacancyApplicationsViewModel(VacancyApplicationsSearchViewModel vacancyApplicationsSearch)
        {
            var messages = new List<string>();
            var viewModel = await _applicationProvider.GetVacancyApplicationsViewModel(vacancyApplicationsSearch);
            if (viewModel.Status == VacancyStatus.Closed)
            {
                messages.Add(VacancyViewModelMessages.Closed);
                return GetMediatorResponse(ApplicationMediatorCodes.GetVacancyApplicationsViewModel.Ok, viewModel, messages, UserMessageLevel.Info);
            }
            return GetMediatorResponse(ApplicationMediatorCodes.GetVacancyApplicationsViewModel.Ok, viewModel);
        }

        public async Task<MediatorResponse<ShareApplicationsViewModel>> ShareApplications(int vacancyReferenceNumber)
        {
            var viewModel = await _applicationProvider.GetShareApplicationsViewModel(vacancyReferenceNumber);

            return GetMediatorResponse(ApplicationMediatorCodes.GetShareApplicationsViewModel.Ok, viewModel);
        }

        public async Task<MediatorResponse<ShareApplicationsViewModel>> ShareApplications(ShareApplicationsViewModel viewModel, UrlHelper urlHelper)
        {
            var validationResult = _shareApplicationsViewModelValidator.Validate(viewModel);

            var newViewModel = await _applicationProvider.GetShareApplicationsViewModel(viewModel.VacancyReferenceNumber);
            newViewModel.SelectedApplicationIds = viewModel.SelectedApplicationIds;

            if (!validationResult.IsValid)
            {
                return GetMediatorResponse(ApplicationMediatorCodes.ShareApplications.FailedValidation, newViewModel, validationResult);
            }

            var applicationLinks = new Dictionary<string, string>();
            foreach (var selectedApplicationId in viewModel.SelectedApplicationIds)
            {
                var application = newViewModel.ApplicationSummaries.Single(a => a.ApplicationId == selectedApplicationId);
                var anonymisedApplicationLinkData = new AnonymisedApplicationLink(application.ApplicationId, _dateTimeService.TwoWeeksFromUtcNow);
                var encryptedLinkData = _encryptionService.Encrypt(anonymisedApplicationLinkData);
                var urlEncodedLinkData = HttpUtility.UrlEncode(encryptedLinkData);
                var routeName = newViewModel.VacancyType == VacancyType.Apprenticeship ? RecruitmentRouteNames.ViewAnonymousApprenticeshipApplication : RecruitmentRouteNames.ViewAnonymousTraineeshipApplication;
                var routeValues = new RouteValueDictionary();
                routeValues["application"] = urlEncodedLinkData;
                var link = urlHelper.RouteUrl(routeName, routeValues);
                applicationLinks[application.ApplicantID] = link;
            }

            await _applicationProvider.ShareApplications(viewModel.VacancyReferenceNumber, newViewModel.ProviderName, applicationLinks,
                _dateTimeService.TwoWeeksFromUtcNow, viewModel.RecipientEmailAddress, viewModel.OptionalMessage);

            return GetMediatorResponse(ApplicationMediatorCodes.ShareApplications.Ok, newViewModel);
        }

        public async Task<MediatorResponse<BulkDeclineCandidatesViewModel>> GetBulkDeclineCandidatesViewModel(BulkDeclineCandidatesViewModel bulkDeclineCandidatesViewModel)
        {
            var viewModel = await _applicationProvider.GetBulkDeclineCandidatesViewModel(bulkDeclineCandidatesViewModel);
            return GetMediatorResponse(ApprenticeshipApplicationMediatorCodes.GetBulkDeclineCandidatesViewModel.Ok, viewModel);
        }

        public async Task<MediatorResponse<BulkDeclineCandidatesViewModel>> ConfirmBulkDeclineCandidates(BulkDeclineCandidatesViewModel bulkDeclineCandidatesViewModel)
        {
            var viewModel = await _applicationProvider.GetBulkDeclineCandidatesViewModel(bulkDeclineCandidatesViewModel);
            var originalSelectedApplicationIds = viewModel.SelectedApplicationIds.ToList();
            viewModel.SelectedApplicationIds = viewModel.SelectedApplicationIds.Where(aid => viewModel.ApplicationSummaries.Any(a => a.ApplicationId == aid)).ToList();
            var validationResult = _bulkDeclineCandidatesViewModelServerValidator.Validate(viewModel);

            if (!validationResult.IsValid)
            {
                viewModel.SelectedApplicationIds = originalSelectedApplicationIds;
                return GetMediatorResponse(ApprenticeshipApplicationMediatorCodes.ConfirmBulkDeclineCandidates.FailedValidation, viewModel, validationResult);
            }

            return GetMediatorResponse(ApprenticeshipApplicationMediatorCodes.ConfirmBulkDeclineCandidates.Ok, viewModel);
        }

        public async Task<MediatorResponse<BulkDeclineCandidatesViewModel>> SendBulkUnsuccessfulDecision(BulkDeclineCandidatesViewModel bulkDeclineCandidatesViewModel)
        {
            var viewModel = await _applicationProvider.GetBulkDeclineCandidatesViewModel(bulkDeclineCandidatesViewModel);

            var validationResult = _bulkDeclineCandidatesViewModelServerValidator.Validate(bulkDeclineCandidatesViewModel);

            if (!validationResult.IsValid)
            {
                return GetMediatorResponse(ApprenticeshipApplicationMediatorCodes.SendBulkUnsuccessfulDecision.FailedValidation, viewModel, validationResult);
            }

            viewModel = _applicationProvider.SendBulkUnsuccessfulDecision(viewModel);

            return GetMediatorResponse(ApprenticeshipApplicationMediatorCodes.SendBulkUnsuccessfulDecision.Ok, viewModel);
        }
    }
}