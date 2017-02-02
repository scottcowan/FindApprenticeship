﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.2.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SFA.DAS.RAA.Api.AcceptanceTests.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class RA577Feature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "RA577.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "RA577", "Inorder to get create vacancies with standards and frameworks\r\nAs a consumer\r\nI s" +
                    "hould be able to see the list of latest standards and frameworks", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "RA577")))
            {
                global::SFA.DAS.RAA.Api.AcceptanceTests.Features.RA577Feature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
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
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Requesting for the latest frameworks")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "RA577")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RA577")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GetFrameworks")]
        public virtual void RequestingForTheLatestFrameworks()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Requesting for the latest frameworks", new string[] {
                        "RA577",
                        "GetFrameworks"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
testRunner.Given("On requesting for all frameworks", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
testRunner.Then("The response status is: OK", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 10
testRunner.And("I see all the latest frameworks", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Requesting all standards")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "RA577")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RA577")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GetStandards")]
        public virtual void RequestingAllStandards()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Requesting all standards", new string[] {
                        "RA577",
                        "GetStandards"});
#line 13
this.ScenarioSetup(scenarioInfo);
#line 14
testRunner.Given("On requesting for all standards", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 15
testRunner.Then("The response status is: OK", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 16
testRunner.And("I see all the latest standards", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Get framework by id that has the status ceased")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "RA577")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RA577")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GetFrameworkByIdReturnNotFound")]
        public virtual void GetFrameworkByIdThatHasTheStatusCeased()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get framework by id that has the status ceased", new string[] {
                        "RA577",
                        "GetFrameworkByIdReturnNotFound"});
#line 19
this.ScenarioSetup(scenarioInfo);
#line 20
testRunner.Given("I request the framework with id: 264", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 21
testRunner.Then("The response status is: NotFound", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 22
testRunner.And("I do not see the information for the framework with id: 264", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Get Framework by id that does exist and is active")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "RA577")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RA577")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GetFrameworkByIdReturnSuccess")]
        public virtual void GetFrameworkByIdThatDoesExistAndIsActive()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get Framework by id that does exist and is active", new string[] {
                        "RA577",
                        "GetFrameworkByIdReturnSuccess"});
#line 25
this.ScenarioSetup(scenarioInfo);
#line 26
testRunner.Given("I request the framework with id: 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 27
testRunner.Then("The response status is: OK", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 28
testRunner.And("I see the information for the framework with id: 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
