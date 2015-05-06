﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.34209
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SFA.Apprenticeships.Web.Candidate.AcceptanceTests.Features.Login
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Login Candidate")]
    [NUnit.Framework.CategoryAttribute("US415")]
    [NUnit.Framework.CategoryAttribute("US458")]
    public partial class LoginCandidateFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "LoginCandidate.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Login Candidate", "As a candidate,\r\nI want to sign in so that I can access my profile,\r\napply for ap" +
                    "prenticeships etc.", ProgrammingLanguage.CSharp, new string[] {
                        "US415",
                        "US458"});
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
#line 8
#line 9
 testRunner.Given("I navigated to the ApprenticeshipSearchPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
 testRunner.And("I am logged out", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.And("I navigated to the ApprenticeshipSearchPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.Then("I am on the ApprenticeshipSearchPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("As a candidate I want to be redirected to the previous page when I login")]
        [NUnit.Framework.CategoryAttribute("US415")]
        public virtual void AsACandidateIWantToBeRedirectedToThePreviousPageWhenILogin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a candidate I want to be redirected to the previous page when I login", new string[] {
                        "US415"});
#line 15
this.ScenarioSetup(scenarioInfo);
#line 8
this.FeatureBackground();
#line 16
 testRunner.Given("I registered an account and activated it", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 17
 testRunner.And("I navigated to the ApprenticeshipSearchPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.When("I choose SignInLink", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 19
 testRunner.And("I am on the LoginPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table1.AddRow(new string[] {
                        "EmailAddress",
                        "{EmailToken}"});
            table1.AddRow(new string[] {
                        "Password",
                        "{PasswordToken}"});
#line 20
 testRunner.And("I enter data", ((string)(null)), table1, "And ");
#line 24
 testRunner.And("I choose SignInButton", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.Then("I am on the ApprenticeshipSearchPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("As a candidate I cannot login with an invalid password")]
        [NUnit.Framework.CategoryAttribute("US415")]
        public virtual void AsACandidateICannotLoginWithAnInvalidPassword()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a candidate I cannot login with an invalid password", new string[] {
                        "US415"});
#line 28
this.ScenarioSetup(scenarioInfo);
#line 8
this.FeatureBackground();
#line 29
 testRunner.Given("I registered an account and activated it", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 30
 testRunner.And("I navigated to the LoginPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
 testRunner.When("I am on the LoginPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table2.AddRow(new string[] {
                        "EmailAddress",
                        "{EmailToken}"});
            table2.AddRow(new string[] {
                        "Password",
                        "{InvalidPasswordToken}"});
#line 32
 testRunner.And("I enter data", ((string)(null)), table2, "And ");
#line 36
 testRunner.And("I choose SignInButton", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
 testRunner.And("I wait to see ValidationSummary", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Rule",
                        "Value"});
            table3.AddRow(new string[] {
                        "ValidationSummaryNoLinkCount",
                        "Equals",
                        "1"});
#line 38
 testRunner.Then("I see", ((string)(null)), table3, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Rule",
                        "Value"});
            table4.AddRow(new string[] {
                        "Text",
                        "Equals",
                        "Please enter a valid email address or password"});
#line 41
 testRunner.And("I am on ValidationSummaryNoLinkItems list item matching criteria", ((string)(null)), table4, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("As a candidate I can login with a registered but unactivated account and am redir" +
            "ected to the activation page")]
        [NUnit.Framework.CategoryAttribute("US458")]
        [NUnit.Framework.CategoryAttribute("US444")]
        [NUnit.Framework.CategoryAttribute("US456")]
        public virtual void AsACandidateICanLoginWithARegisteredButUnactivatedAccountAndAmRedirectedToTheActivationPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a candidate I can login with a registered but unactivated account and am redir" +
                    "ected to the activation page", new string[] {
                        "US458",
                        "US444",
                        "US456"});
#line 46
this.ScenarioSetup(scenarioInfo);
#line 8
this.FeatureBackground();
#line 47
 testRunner.Given("I registered an account but did not activate it", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 48
 testRunner.And("I navigated to the LoginPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
 testRunner.When("I am on the LoginPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table5.AddRow(new string[] {
                        "EmailAddress",
                        "{EmailToken}"});
            table5.AddRow(new string[] {
                        "Password",
                        "{PasswordToken}"});
#line 50
 testRunner.And("I enter data", ((string)(null)), table5, "And ");
#line 54
 testRunner.And("I choose SignInButton", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.And("I am on the ActivationPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table6.AddRow(new string[] {
                        "ActivationCode",
                        "{ActivationCodeToken}"});
#line 56
 testRunner.And("I enter data", ((string)(null)), table6, "And ");
#line 59
 testRunner.And("I choose ActivateButton", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
 testRunner.Then("I wait 120 second for the MonitoringInformationPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 61
 testRunner.When("I choose SkipLink", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 62
 testRunner.Then("I am on the ApprenticeshipSearchPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
