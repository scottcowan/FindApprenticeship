﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.34014
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SFA.Apprenticeships.Web.Candidate.IntegrationTests.SpecFlow.Features.VacancySearchFeature
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("VacancySearchResults")]
    [NUnit.Framework.CategoryAttribute("vacancysearch")]
    [NUnit.Framework.CategoryAttribute("US58")]
    [NUnit.Framework.CategoryAttribute("US230")]
    [NUnit.Framework.CategoryAttribute("US258")]
    public partial class VacancySearchResultsFeature : FluentAutomation.FluentTest
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "VacancySearchResults.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "VacancySearchResults", "In order to confirm a candidate can search for vacancies\r\nas a candidate\r\nI want " +
                    "to be find relevant vacancies in my area", ProgrammingLanguage.CSharp, new string[] {
                        "vacancysearch",
                        "US58",
                        "US230",
                        "US258"});
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
            ScenarioContext.Current[ScenarioContext.Current.ScenarioInfo.Title] = this;
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("View apprenticeships in my area")]
        public virtual void ViewApprenticeshipsInMyArea()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("View apprenticeships in my area", ((string[])(null)));
#line 7
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Location",
                        "Distance (miles)"});
            table1.AddRow(new string[] {
                        "Warwick",
                        "10 miles"});
#line 8
 testRunner.Given("I am a candidate with preferences", ((string)(null)), table1, "Given ");
#line 11
 testRunner.And("I have searched for vacancies", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.When("I see my first \'10\' search results", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
 testRunner.Then("I expect the search results to be sorted by \'sort-distance\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("View apprenticeships in my area - next page")]
        public virtual void ViewApprenticeshipsInMyArea_NextPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("View apprenticeships in my area - next page", ((string[])(null)));
#line 15
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Location",
                        "Distance (miles)"});
            table2.AddRow(new string[] {
                        "Warwick (Warwickshire)",
                        "10 miles"});
#line 16
 testRunner.Given("I am a candidate with preferences", ((string)(null)), table2, "Given ");
#line 19
 testRunner.And("I have searched for vacancies", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.When("I see my first \'10\' search results", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 21
 testRunner.And("I navigate to the next page of \'10\' results", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.Then("I expect to see the \'next\' page of results", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
