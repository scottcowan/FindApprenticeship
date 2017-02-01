﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.0.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SFA.Apprenticeships.Web.Candidate.AcceptanceTests.Features.TraineeshipApplication
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Apply for a traineeship vacancy")]
    [NUnit.Framework.CategoryAttribute("US583")]
    public partial class ApplyForATraineeshipVacancyFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ApplyForTraineeship.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Apply for a traineeship vacancy", "\tAs a candidate\r\n\tI want to submit traineeship applications \r\n\tso that it can be " +
                    "reviewed by a Vacancy Manager", ProgrammingLanguage.CSharp, new string[] {
                        "US583"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 7
#line 8
 testRunner.Given("I navigated to the TraineeshipSearchPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.And("I am logged out", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.And("I navigated to the TraineeshipSearchPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.Then("I am on the TraineeshipSearchPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("As a candidate I am taken to login or create an account when viewing traineeship " +
            "details")]
        [NUnit.Framework.CategoryAttribute("US592")]
        public virtual void AsACandidateIAmTakenToLoginOrCreateAnAccountWhenViewingTraineeshipDetails()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a candidate I am taken to login or create an account when viewing traineeship " +
                    "details", new string[] {
                        "US592"});
#line 14
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 15
 testRunner.Given("I select the \"first\" traineeship vacancy in location \"N7 8LS\" that can apply by t" +
                    "his website", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 16
 testRunner.When("I am on the TraineeshipDetailsPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
 testRunner.And("I choose ApplyButton", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.Then("I am on the LoginPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("As a candidate I want to enter my qualifications and work experience in a trainee" +
            "ship application")]
        [NUnit.Framework.CategoryAttribute("PrimaryTransaction")]
        public virtual void AsACandidateIWantToEnterMyQualificationsAndWorkExperienceInATraineeshipApplication()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a candidate I want to enter my qualifications and work experience in a trainee" +
                    "ship application", new string[] {
                        "PrimaryTransaction"});
#line 21
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 22
 testRunner.Given("I have registered a new candidate", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 23
 testRunner.When("I select the \"first\" traineeship vacancy in location \"N7 8LS\" that can apply by t" +
                    "his website", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 24
 testRunner.Then("I am on the TraineeshipDetailsPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 25
 testRunner.When("I choose ApplyButton", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 26
 testRunner.Then("I am on the TraineeshipApplicationPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 29
 testRunner.When("I choose QualificationsYes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 30
 testRunner.And("I choose SaveQualification", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Rule",
                        "Value"});
            table1.AddRow(new string[] {
                        "QualificationsValidationErrorsCount",
                        "Equals",
                        "4"});
#line 31
 testRunner.Then("I see", ((string)(null)), table1, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Rule",
                        "Value"});
            table2.AddRow(new string[] {
                        "Text",
                        "Equals",
                        "GCSE"});
#line 34
 testRunner.When("I am on QualificationTypeDropdown list item matching criteria", ((string)(null)), table2, "When ");
#line 37
 testRunner.And("I choose WrappedElement", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
 testRunner.And("I am on the TraineeshipApplicationPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table3.AddRow(new string[] {
                        "SubjectYear",
                        "2012"});
            table3.AddRow(new string[] {
                        "SubjectName",
                        "SubjectName"});
            table3.AddRow(new string[] {
                        "SubjectGrade",
                        "SubjectGrade"});
#line 39
 testRunner.When("I enter data", ((string)(null)), table3, "When ");
#line 44
 testRunner.And("I am on the TraineeshipApplicationPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
 testRunner.And("I choose SaveQualification", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
 testRunner.And("I choose SaveQualification", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
 testRunner.And("I wait for 30 seconds to see QualificationsSummary", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Rule",
                        "Value"});
            table4.AddRow(new string[] {
                        "QualificationsSummaryCount",
                        "Equals",
                        "1"});
#line 49
 testRunner.Then("I see", ((string)(null)), table4, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Rule",
                        "Value"});
            table5.AddRow(new string[] {
                        "Subject",
                        "Equals",
                        "SubjectName"});
            table5.AddRow(new string[] {
                        "Year",
                        "Equals",
                        "2012"});
            table5.AddRow(new string[] {
                        "Grade",
                        "Equals",
                        "SubjectGrade"});
#line 52
 testRunner.And("I am on QualificationsSummaryItems list item matching criteria", ((string)(null)), table5, "And ");
#line 57
 testRunner.When("I choose RemoveQualificationLink", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 58
 testRunner.And("I am on the TraineeshipApplicationPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Rule",
                        "Value"});
            table6.AddRow(new string[] {
                        "QualificationsSummary",
                        "Does Not Exist",
                        ""});
#line 59
 testRunner.Then("I see", ((string)(null)), table6, "Then ");
#line 64
 testRunner.When("I choose WorkExperienceYes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 65
 testRunner.And("I choose SaveWorkExperience", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Rule",
                        "Value"});
            table7.AddRow(new string[] {
                        "WorkExperienceValidationErrorsCount",
                        "Equals",
                        "5"});
#line 66
 testRunner.Then("I see", ((string)(null)), table7, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table8.AddRow(new string[] {
                        "WorkEmployer",
                        "WorkEmployer"});
            table8.AddRow(new string[] {
                        "WorkTitle",
                        "WorkTitle"});
            table8.AddRow(new string[] {
                        "WorkRole",
                        "WorkRole"});
            table8.AddRow(new string[] {
                        "WorkFromYear",
                        "2011"});
            table8.AddRow(new string[] {
                        "WorkToYear",
                        "2012"});
#line 69
 testRunner.When("I enter data", ((string)(null)), table8, "When ");
#line 76
 testRunner.And("I choose SaveWorkExperience", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 78
 testRunner.And("I choose SaveWorkExperience", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 79
 testRunner.Then("I wait for 30 seconds to see WorkExperienceSummary", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Rule",
                        "Value"});
            table9.AddRow(new string[] {
                        "WorkExperiencesCount",
                        "Equals",
                        "1"});
#line 80
 testRunner.Then("I see", ((string)(null)), table9, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Rule",
                        "Value"});
            table10.AddRow(new string[] {
                        "Employer",
                        "Equals",
                        "WorkEmployer"});
            table10.AddRow(new string[] {
                        "JobTitle",
                        "Equals",
                        "WorkTitle"});
            table10.AddRow(new string[] {
                        "MainDuties",
                        "Equals",
                        "WorkRole"});
#line 83
 testRunner.And("I am on WorkExperienceSummaryItems list item matching criteria", ((string)(null)), table10, "And ");
#line 88
 testRunner.When("I choose RemoveWorkExperienceLink", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 89
 testRunner.And("I am on the TraineeshipApplicationPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Rule",
                        "Value"});
            table11.AddRow(new string[] {
                        "WorkExperienceSummary",
                        "Does Not Exist",
                        ""});
#line 90
 testRunner.Then("I see", ((string)(null)), table11, "Then ");
#line 95
 testRunner.When("I choose TrainingCoursesYes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 96
 testRunner.And("I choose SaveTrainingCourseButton", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Rule",
                        "Value"});
            table12.AddRow(new string[] {
                        "TrainingCourseValidationErrorsCount",
                        "Equals",
                        "4"});
#line 97
 testRunner.Then("I see", ((string)(null)), table12, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table13.AddRow(new string[] {
                        "TrainingCourseProvider",
                        "TrainingCourseProvider"});
            table13.AddRow(new string[] {
                        "TrainingCourseTitle",
                        "TrainingCourseTitle"});
            table13.AddRow(new string[] {
                        "TrainingCourseFromYear",
                        "2011"});
            table13.AddRow(new string[] {
                        "TrainingCourseToYear",
                        "2012"});
#line 100
 testRunner.When("I enter data", ((string)(null)), table13, "When ");
#line 106
 testRunner.And("I choose SaveTrainingCourseButton", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 108
 testRunner.And("I choose SaveTrainingCourseButton", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 109
 testRunner.Then("I wait for 30 seconds to see TrainingCourseSummary", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Rule",
                        "Value"});
            table14.AddRow(new string[] {
                        "TrainingCourseCount",
                        "Equals",
                        "1"});
#line 110
 testRunner.Then("I see", ((string)(null)), table14, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Rule",
                        "Value"});
            table15.AddRow(new string[] {
                        "Provider",
                        "Equals",
                        "TrainingCourseProvider"});
            table15.AddRow(new string[] {
                        "CourseTitle",
                        "Equals",
                        "TrainingCourseTitle"});
#line 113
 testRunner.And("I am on TrainingCourseSummaryItems list item matching criteria", ((string)(null)), table15, "And ");
#line 117
 testRunner.When("I choose RemoveTrainingCourseLink", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 118
 testRunner.And("I am on the TraineeshipApplicationPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Rule",
                        "Value"});
            table16.AddRow(new string[] {
                        "TrainingCourseSummary",
                        "Does Not Exist",
                        ""});
#line 119
 testRunner.Then("I see", ((string)(null)), table16, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table17.AddRow(new string[] {
                        "Candidate_EmployerQuestionAnswers_CandidateAnswer1",
                        "Emp 1"});
            table17.AddRow(new string[] {
                        "Candidate_EmployerQuestionAnswers_CandidateAnswer2",
                        "Emp 2"});
#line 124
 testRunner.When("I enter employer question data if present", ((string)(null)), table17, "When ");
#line 128
 testRunner.And("I choose QualificationsYes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table18 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Rule",
                        "Value"});
            table18.AddRow(new string[] {
                        "Text",
                        "Equals",
                        "GCSE"});
#line 129
 testRunner.And("I am on QualificationTypeDropdown list item matching criteria", ((string)(null)), table18, "And ");
#line 132
 testRunner.And("I choose WrappedElement", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 133
 testRunner.And("I am on the TraineeshipApplicationPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table19 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table19.AddRow(new string[] {
                        "SubjectYear",
                        "2012"});
            table19.AddRow(new string[] {
                        "SubjectName",
                        "SubjectName"});
            table19.AddRow(new string[] {
                        "SubjectGrade",
                        "SubjectGrade"});
#line 134
 testRunner.And("I enter data", ((string)(null)), table19, "And ");
#line 139
 testRunner.And("I choose SaveQualification", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 141
 testRunner.When("I choose WorkExperienceYes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table20 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table20.AddRow(new string[] {
                        "WorkEmployer",
                        "WorkEmployer"});
            table20.AddRow(new string[] {
                        "WorkTitle",
                        "WorkTitle"});
            table20.AddRow(new string[] {
                        "WorkRole",
                        "WorkRole"});
            table20.AddRow(new string[] {
                        "WorkFromYear",
                        "2011"});
            table20.AddRow(new string[] {
                        "WorkToYear",
                        "2012"});
#line 142
 testRunner.And("I enter data", ((string)(null)), table20, "And ");
#line 149
 testRunner.And("I choose SaveWorkExperience", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 151
 testRunner.When("I choose TrainingCoursesYes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table21 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table21.AddRow(new string[] {
                        "TrainingCourseProvider",
                        "TrainingProvider"});
            table21.AddRow(new string[] {
                        "TrainingCourseTitle",
                        "TrainingCourseTitle"});
            table21.AddRow(new string[] {
                        "TrainingCourseFromYear",
                        "2011"});
            table21.AddRow(new string[] {
                        "TrainingCourseToYear",
                        "2012"});
#line 152
 testRunner.And("I enter data", ((string)(null)), table21, "And ");
#line 158
 testRunner.And("I choose SaveTrainingCourseButton", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 161
 testRunner.And("I choose ApplyButton", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 162
 testRunner.Then("I am on the TraineeshipWhatsNextPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
