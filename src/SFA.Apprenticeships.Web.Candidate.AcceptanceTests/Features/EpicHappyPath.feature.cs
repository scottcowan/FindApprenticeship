﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.18408
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SFA.Apprenticeships.Web.Candidate.AcceptanceTests.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("EpicHappyPath")]
    [NUnit.Framework.IgnoreAttribute()]
    public partial class EpicHappyPathFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "EpicHappyPath.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "EpicHappyPath", "In order to test the epic happy path\r\nAs a candidate\r\nI want to be able to search" +
                    ", view, register, login, save, apply, view, resume and dismiss applications", ProgrammingLanguage.CSharp, new string[] {
                        "ignore"});
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
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Epic happy path")]
        public virtual void EpicHappyPath()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Epic happy path", ((string[])(null)));
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given("I navigated to the VacancySearchPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table1.AddRow(new string[] {
                        "Location",
                        "Coventry"});
            table1.AddRow(new string[] {
                        "WithInDistance",
                        "40 miles"});
#line 9
 testRunner.When("I enter data", ((string)(null)), table1, "When ");
#line 13
 testRunner.And("I choose Search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.Then("I am on the VacancySearchResultPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 15
 testRunner.When("I choose FirstVacancyLink", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 16
 testRunner.Then("I am on the VacancyDetailsPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 17
 testRunner.When("I choose ApplyButton", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
 testRunner.Then("I am on the LoginPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 19
 testRunner.When("I choose CreateAccountLink", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 20
 testRunner.Then("I am on the RegisterCandidatePage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 21
 testRunner.When("I have created a new email address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table2.AddRow(new string[] {
                        "Firstname",
                        "FirstnameTest"});
            table2.AddRow(new string[] {
                        "Lastname",
                        "LastnameTest"});
            table2.AddRow(new string[] {
                        "Phonenumber",
                        "07970523193"});
            table2.AddRow(new string[] {
                        "EmailAddress",
                        "{EmailToken}"});
            table2.AddRow(new string[] {
                        "PostcodeSearch",
                        "N7 8LS"});
            table2.AddRow(new string[] {
                        "Day",
                        "01"});
            table2.AddRow(new string[] {
                        "Month",
                        "01"});
            table2.AddRow(new string[] {
                        "Year",
                        "2000"});
            table2.AddRow(new string[] {
                        "Password",
                        "?Password01!"});
#line 22
 testRunner.And("I enter data", ((string)(null)), table2, "And ");
#line 33
 testRunner.And("I choose HasAcceptedTermsAndConditions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
 testRunner.And("I choose FindAddresses", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Rule",
                        "Value"});
            table3.AddRow(new string[] {
                        "Text",
                        "Equals",
                        "Flat A, 6 Furlong Road"});
#line 35
 testRunner.And("I am on AddressDropdown list item matching criteria", ((string)(null)), table3, "And ");
#line 38
 testRunner.And("I choose WrappedElement", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
 testRunner.And("I am on the RegisterCandidatePage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
 testRunner.And("I choose CreateAccountButton", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
 testRunner.Then("I wait 120 second for the ActivationPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 42
 testRunner.When("I get the token for my newly created account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table4.AddRow(new string[] {
                        "ActivationCode",
                        "{ActivationToken}"});
#line 43
 testRunner.And("I enter data", ((string)(null)), table4, "And ");
#line 46
 testRunner.And("I choose ActivateButton", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
 testRunner.Then("I am on the ApplicationPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table5.AddRow(new string[] {
                        "EducationNameOfSchool",
                        "SchoolName"});
            table5.AddRow(new string[] {
                        "EducationFromYear",
                        "2010"});
            table5.AddRow(new string[] {
                        "EducationToYear",
                        "2012"});
            table5.AddRow(new string[] {
                        "WhatAreYourStrengths",
                        "My strengths"});
            table5.AddRow(new string[] {
                        "WhatCanYouImprove",
                        "What can I improve"});
            table5.AddRow(new string[] {
                        "HobbiesAndInterests",
                        "Hobbies and interests"});
            table5.AddRow(new string[] {
                        "WhatCanWeDoToSupportYou",
                        "What can we do to support you"});
#line 48
 testRunner.When("I enter data", ((string)(null)), table5, "When ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table6.AddRow(new string[] {
                        "Candidate_EmployerQuestionAnswers_CandidateAnswer1",
                        "Emp 1"});
            table6.AddRow(new string[] {
                        "Candidate_EmployerQuestionAnswers_CandidateAnswer2",
                        "Emp 2"});
#line 57
 testRunner.And("I enter employer question data if present", ((string)(null)), table6, "And ");
#line 61
 testRunner.And("I choose ApplyButton", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
 testRunner.Then("I am on the ApplicationPreviewPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
