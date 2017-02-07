﻿namespace SFA.Apprenticeships.Web.Recruit.Controllers
{
    using System.Threading.Tasks;
    using Application.Interfaces;
    using Common.Mediators;
    using Mediators.Application;
    using System.Web.Mvc;

    public class EmployerApplicationController : Common.Controllers.ControllerBase
    {
        private readonly IApprenticeshipApplicationMediator _apprenticeshipApplicationMediator;
        private readonly ITraineeshipApplicationMediator _traineeshipApplicationMediator;

        public EmployerApplicationController(IConfigurationService configurationService, ILogService loggingService,
            IApprenticeshipApplicationMediator apprenticeshipApplicationMediator, ITraineeshipApplicationMediator traineeshipApplicationMediator)
            : base(configurationService, loggingService)
        {
            _apprenticeshipApplicationMediator = apprenticeshipApplicationMediator;
            _traineeshipApplicationMediator = traineeshipApplicationMediator;
        }

        public async Task<ActionResult> ViewAnonymisedApprenticeship(string application)
        {
            var response = await _apprenticeshipApplicationMediator.View(application);

            switch (response.Code)
            {
                case ApprenticeshipApplicationMediatorCodes.View.Ok:
                    return View(response.ViewModel);
                case ApprenticeshipApplicationMediatorCodes.View.LinkExpired:
                    return View("LinkExpired");
                default:
                    throw new InvalidMediatorCodeException(response.Code);
            }
        }

        public async Task<ActionResult> ViewAnonymisedTraineeship(string application)
        {
            var response = await _traineeshipApplicationMediator.View(application);

            switch (response.Code)
            {
                case TraineeshipApplicationMediatorCodes.View.Ok:
                    return View(response.ViewModel);
                case TraineeshipApplicationMediatorCodes.View.LinkExpired:
                    return View("LinkExpired");
                default:
                    throw new InvalidMediatorCodeException(response.Code);
            }
        }
    }
}