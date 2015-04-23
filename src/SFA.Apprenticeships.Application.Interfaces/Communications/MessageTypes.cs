﻿namespace SFA.Apprenticeships.Application.Interfaces.Communications
{
    // TODO: AG: should these be numbered?
    public enum MessageTypes
    {
        SendActivationCode = 0,
        SendPasswordResetCode = 1,
        SendAccountUnlockCode = 2,
        SendMobileVerificationCode = 3,
        ApprenticeshipApplicationSubmitted = 4,
        TraineeshipApplicationSubmitted = 5,
        PasswordChanged = 6,
        DailyDigest = 7,
        CandidateContactMessage = 8,
        SavedSearchAlert = 9,
        ApprenticeshipApplicationSuccessful = 10,
        ApprenticeshipApplicationUnsuccessful = 11,
        ApprenticeshipApplicationsUnsuccessfulSummary = 12,
        ApprenticeshipApplicationExpiringDraft = 13,
        ApprenticeshipApplicationExpiringDraftsSummary = 14,
        SendPendingUsernameCode = 15,
        SendEmailReminder = 16
        //EmployerContactMessage
    }
}
