﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.42000
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SFA.Apprenticeships.Web.Candidate.AcceptanceTests.Features.ApprenticeshipSearch
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Apprenticeship Search Validation")]
    [NUnit.Framework.CategoryAttribute("US496")]
    [NUnit.Framework.CategoryAttribute("US449")]
    public partial class ApprenticeshipSearchValidationFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ApprenticeshipSearchValidation.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Apprenticeship Search Validation", "In order to find a apprenticeship vacancy quickly\r\nAs a candidate\r\nI want invalid" +
                    " inputs to be highlighted before searching", ProgrammingLanguage.CSharp, new string[] {
                        "US496",
                        "US449"});
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
 testRunner.Given("I navigated to the ApprenticeshipSearchPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.And("I am logged out", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.And("I navigated to the ApprenticeshipSearchPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.Then("I am on the ApprenticeshipSearchPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Show validation error message when no location entered")]
        [NUnit.Framework.CategoryAttribute("SmokeTests")]
        public virtual void ShowValidationErrorMessageWhenNoLocationEntered()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Show validation error message when no location entered", new string[] {
                        "SmokeTests"});
#line 14
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 15
 testRunner.Given("I navigated to the ApprenticeshipSearchPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table1.AddRow(new string[] {
                        "WithInDistance",
                        "40 miles"});
#line 16
 testRunner.When("I enter data", ((string)(null)), table1, "When ");
#line 19
 testRunner.When("I choose Search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 20
 testRunner.Then("I am on the ApprenticeshipSearchResultPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Rule",
                        "Value"});
            table2.AddRow(new string[] {
                        "ValidationFieldErrorCount",
                        "Equals",
                        "1"});
#line 21
 testRunner.And("I see", ((string)(null)), table2, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Show validation error message when single character location entered")]
        [NUnit.Framework.CategoryAttribute("SmokeTests")]
        public virtual void ShowValidationErrorMessageWhenSingleCharacterLocationEntered()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Show validation error message when single character location entered", new string[] {
                        "SmokeTests"});
#line 26
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 27
 testRunner.Given("I navigated to the ApprenticeshipSearchPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 28
 testRunner.Then("I clear the Location field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table3.AddRow(new string[] {
                        "Location",
                        "M"});
#line 29
 testRunner.When("I enter data", ((string)(null)), table3, "When ");
#line 32
 testRunner.And("I choose SearchHeader", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
 testRunner.And("I choose Search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
 testRunner.Then("I am on the ApprenticeshipSearchPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Rule",
                        "Value"});
            table4.AddRow(new string[] {
                        "ValidationFieldErrorCount",
                        "Equals",
                        "1"});
#line 35
 testRunner.And("I see", ((string)(null)), table4, "And ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Rule",
                        "Value"});
            table5.AddRow(new string[] {
                        "Text",
                        "Equals",
                        "Location must be 3 or more characters or a postcode"});
#line 38
 testRunner.And("I am on ValidationFieldErrorItems list item matching criteria", ((string)(null)), table5, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Show validation error message when two character location entered that is not a p" +
            "artial postcode")]
        [NUnit.Framework.CategoryAttribute("SmokeTests")]
        public virtual void ShowValidationErrorMessageWhenTwoCharacterLocationEnteredThatIsNotAPartialPostcode()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Show validation error message when two character location entered that is not a p" +
                    "artial postcode", new string[] {
                        "SmokeTests"});
#line 43
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 44
 testRunner.Given("I navigated to the ApprenticeshipSearchPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 45
 testRunner.Then("I clear the Location field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table6.AddRow(new string[] {
                        "Location",
                        "MA"});
#line 46
 testRunner.When("I enter data", ((string)(null)), table6, "When ");
#line 49
 testRunner.And("I choose SearchHeader", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
 testRunner.When("I choose Search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 51
 testRunner.Then("I am on the ApprenticeshipSearchResultPage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Rule",
                        "Value"});
            table7.AddRow(new string[] {
                        "ValidationFieldErrorCount",
                        "Equals",
                        "1"});
#line 52
 testRunner.And("I see", ((string)(null)), table7, "And ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Rule",
                        "Value"});
            table8.AddRow(new string[] {
                        "Text",
                        "Equals",
                        "Location must be 3 or more characters or a postcode"});
#line 55
 testRunner.And("I am on ValidationFieldErrorItems list item matching criteria", ((string)(null)), table8, "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
