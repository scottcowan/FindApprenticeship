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
    public partial class RA578Feature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "RA578.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "RA578", "\tIn order to fully populate a vacancy\r\n\tAs an API user\r\n\tI want to be able to ret" +
                    "rieve County, Local Authority and Region information", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "RA578")))
            {
                global::SFA.DAS.RAA.Api.AcceptanceTests.Features.RA578Feature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Get all Counties")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "RA578")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RA578")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GetAllCounties")]
        public virtual void GetAllCounties()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get all Counties", new string[] {
                        "RA578",
                        "GetAllCounties"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given("I request all counties", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.Then("The response status is: OK", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 10
 testRunner.And("I see all county information", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Get County by id")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "RA578")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RA578")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GetCountyById")]
        public virtual void GetCountyById()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get County by id", new string[] {
                        "RA578",
                        "GetCountyById"});
#line 13
this.ScenarioSetup(scenarioInfo);
#line 14
 testRunner.Given("I request the county with id: 4", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 15
 testRunner.Then("The response status is: OK", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 16
 testRunner.And("I see the information for the county with id: 4", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Get County by id that doesn\'t exist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "RA578")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RA578")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GetCountyById")]
        public virtual void GetCountyByIdThatDoesntExist()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get County by id that doesn\'t exist", new string[] {
                        "RA578",
                        "GetCountyById"});
#line 19
this.ScenarioSetup(scenarioInfo);
#line 20
 testRunner.Given("I request the county with id: 999", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 21
 testRunner.Then("The response status is: NotFound", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 22
 testRunner.And("I do not see the information for the county with id: 999", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Get County by code")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "RA578")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RA578")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GetCountyByCode")]
        public virtual void GetCountyByCode()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get County by code", new string[] {
                        "RA578",
                        "GetCountyByCode"});
#line 25
this.ScenarioSetup(scenarioInfo);
#line 26
 testRunner.Given("I request the county with code: DER", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 27
 testRunner.Then("The response status is: OK", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 28
 testRunner.And("I see the information for the county with code: DER", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Get County by code that doesn\'t exist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "RA578")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RA578")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GetCountyByCode")]
        public virtual void GetCountyByCodeThatDoesntExist()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get County by code that doesn\'t exist", new string[] {
                        "RA578",
                        "GetCountyByCode"});
#line 31
this.ScenarioSetup(scenarioInfo);
#line 32
 testRunner.Given("I request the county with code: XXX", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 33
 testRunner.Then("The response status is: NotFound", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 34
 testRunner.And("I do not see the information for the county with code: XXX", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Get all LocalAuthorities")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "RA578")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RA578")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GetAllLocalAuthorities")]
        public virtual void GetAllLocalAuthorities()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get all LocalAuthorities", new string[] {
                        "RA578",
                        "GetAllLocalAuthorities"});
#line 37
this.ScenarioSetup(scenarioInfo);
#line 38
 testRunner.Given("I request all local authorities", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 39
 testRunner.Then("The response status is: OK", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 40
 testRunner.And("I see all local authority information", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Get LocalAuthority by id")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "RA578")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RA578")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GetLocalAuthorityById")]
        public virtual void GetLocalAuthorityById()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get LocalAuthority by id", new string[] {
                        "RA578",
                        "GetLocalAuthorityById"});
#line 43
this.ScenarioSetup(scenarioInfo);
#line 44
 testRunner.Given("I request the local authority with id: 160", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 45
 testRunner.Then("The response status is: OK", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 46
 testRunner.And("I see the information for the local authority with id: 160", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Get LocalAuthority by id that doesn\'t exist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "RA578")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RA578")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GetLocalAuthorityById")]
        public virtual void GetLocalAuthorityByIdThatDoesntExist()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get LocalAuthority by id that doesn\'t exist", new string[] {
                        "RA578",
                        "GetLocalAuthorityById"});
#line 49
this.ScenarioSetup(scenarioInfo);
#line 50
 testRunner.Given("I request the local authority with id: 999", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 51
 testRunner.Then("The response status is: NotFound", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 52
 testRunner.And("I do not see the information for the local authority with id: 999", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Get LocalAuthority by code")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "RA578")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RA578")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GetLocalAuthorityByCode")]
        public virtual void GetLocalAuthorityByCode()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get LocalAuthority by code", new string[] {
                        "RA578",
                        "GetLocalAuthorityByCode"});
#line 55
this.ScenarioSetup(scenarioInfo);
#line 56
 testRunner.Given("I request the local authority with code: 41UD", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 57
 testRunner.Then("The response status is: OK", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 58
 testRunner.And("I see the information for the local authority with code: 41UD", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Get LocalAuthority by code that doesn\'t exist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "RA578")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RA578")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GetLocalAuthorityByCode")]
        public virtual void GetLocalAuthorityByCodeThatDoesntExist()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get LocalAuthority by code that doesn\'t exist", new string[] {
                        "RA578",
                        "GetLocalAuthorityByCode"});
#line 61
this.ScenarioSetup(scenarioInfo);
#line 62
 testRunner.Given("I request the local authority with code: XXXX", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 63
 testRunner.Then("The response status is: NotFound", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 64
 testRunner.And("I do not see the information for the local authority with code: XXXX", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Get all Regions")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "RA578")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RA578")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GetAllRegions")]
        public virtual void GetAllRegions()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get all Regions", new string[] {
                        "RA578",
                        "GetAllRegions"});
#line 67
this.ScenarioSetup(scenarioInfo);
#line 68
 testRunner.Given("I request all regions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 69
 testRunner.Then("The response status is: OK", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 70
 testRunner.And("I see all region information", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Get Region by id")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "RA578")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RA578")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GetRegionById")]
        public virtual void GetRegionById()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get Region by id", new string[] {
                        "RA578",
                        "GetRegionById"});
#line 73
this.ScenarioSetup(scenarioInfo);
#line 74
 testRunner.Given("I request the region with id: 1007", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 75
 testRunner.Then("The response status is: OK", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 76
 testRunner.And("I see the information for the region with id: 1007", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Get Region by id that doesn\'t exist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "RA578")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RA578")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GetRegionById")]
        public virtual void GetRegionByIdThatDoesntExist()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get Region by id that doesn\'t exist", new string[] {
                        "RA578",
                        "GetRegionById"});
#line 79
this.ScenarioSetup(scenarioInfo);
#line 80
 testRunner.Given("I request the region with id: 9999", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 81
 testRunner.Then("The response status is: NotFound", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 82
 testRunner.And("I do not see the information for the region with id: 9999", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Get Region by code")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "RA578")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RA578")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GetRegionByCode")]
        public virtual void GetRegionByCode()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get Region by code", new string[] {
                        "RA578",
                        "GetRegionByCode"});
#line 85
this.ScenarioSetup(scenarioInfo);
#line 86
 testRunner.Given("I request the region with code: WM", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 87
 testRunner.Then("The response status is: OK", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 88
 testRunner.And("I see the information for the region with code: WM", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Get Region by code that doesn\'t exist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "RA578")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RA578")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GetRegionByCode")]
        public virtual void GetRegionByCodeThatDoesntExist()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get Region by code that doesn\'t exist", new string[] {
                        "RA578",
                        "GetRegionByCode"});
#line 91
this.ScenarioSetup(scenarioInfo);
#line 92
 testRunner.Given("I request the region with code: XX", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 93
 testRunner.Then("The response status is: NotFound", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 94
 testRunner.And("I do not see the information for the region with code: XX", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
