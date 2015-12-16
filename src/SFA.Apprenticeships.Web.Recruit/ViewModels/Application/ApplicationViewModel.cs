﻿namespace SFA.Apprenticeships.Web.Recruit.ViewModels.Application
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Constants.ViewModels;

    public class ApplicationViewModel
    {
        public Guid ApplicationId { get; set; }

        public ApplicationVacancyViewModel Vacancy { get; set; }

        public ApplicantDetailsViewModel ApplicantDetails { get; set; }

        public AboutYouViewModel AboutYou { get; set; }

        public EducationViewModel Education { get; set; }

        public IList<QualificationViewModel> Qualifications { get; set; }

        public IList<WorkExperienceViewModel> WorkExperience { get; set; }

        public IList<TrainingCourseViewModel> TrainingCourses { get; set; }

        public VacancyQuestionAnswersViewModel VacancyQuestionAnswers { get; set; }

        [Display(Name = ApplicationViewModelMessages.Notes.LabelText)]
        public string Notes { get; set; }
    }
}