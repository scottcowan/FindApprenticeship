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
namespace SFA.Apprenticeships.Web.Candidate.IntegrationTests.SpecFlow.Features.VacancyFeatures
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("VacancyDetails")]
    [NUnit.Framework.CategoryAttribute("vacancydetail")]
    [NUnit.Framework.CategoryAttribute("US124")]
    [NUnit.Framework.CategoryAttribute("US238")]
    public partial class VacancyDetailsFeature : FluentAutomation.FluentTest
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "VacancyDetails.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "VacancyDetails", "In order to confirm a candidate can view vacnacy full details.\r\nas a candidate\r\nI" +
                    " want to be read full vacancies details in my area", ProgrammingLanguage.CSharp, new string[] {
                        "vacancydetail",
                        "US124",
                        "US238"});
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
        [NUnit.Framework.DescriptionAttribute("View apprenticeship details in my area")]
        [NUnit.Framework.CategoryAttribute("mytag")]
        public virtual void ViewApprenticeshipDetailsInMyArea()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("View apprenticeship details in my area", new string[] {
                        "mytag"});
#line 8
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Location",
                        "Distance"});
            table1.AddRow(new string[] {
                        "Warwick",
                        "10 miles"});
#line 9
 testRunner.Given("I am a candidate with preferences", ((string)(null)), table1, "Given ");
#line 12
 testRunner.When("I search for vacancies", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
 testRunner.Then("I expect to see search results", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
