﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace RestaurantTestsSpecFlow.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Calculate Total Bill for a Group Ordering Starters, Mains, and Drinks Based on Or" +
        "der Time")]
    public partial class CalculateTotalBillForAGroupOrderingStartersMainsAndDrinksBasedOnOrderTimeFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "checkoutSystemForRestaurant.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Calculate Total Bill for a Group Ordering Starters, Mains, and Drinks Based on Or" +
                    "der Time", @"  As a restaurant owner
  I want to ensure the checkout system correctly calculates the total bill
  So that customers are charged accurately based on their orders and discounts

  Rules:
    - Starters cost £4.00 each.
    - Mains cost £7.00 each.
    - Drinks cost £2.50 each.
    - Drinks ordered before 19:00 receive a 30% discount.
    - A 10% service charge is applied to the total cost of food (starters and mains).", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
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
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Calculate correct bill for a group of 4 with one member canceling their order who" +
            " came before 19:00")]
        public virtual void CalculateCorrectBillForAGroupOf4WithOneMemberCancelingTheirOrderWhoCameBefore1900()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Calculate correct bill for a group of 4 with one member canceling their order who" +
                    " came before 19:00", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 21
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                            "Item",
                            "Quantity",
                            "Price",
                            "orderedTime"});
                table1.AddRow(new string[] {
                            "Starter",
                            "4",
                            "4.00",
                            "2025-03-19T18:30:23.317z"});
                table1.AddRow(new string[] {
                            "Main",
                            "4",
                            "7.00",
                            "2025-03-19T18:25:23.317z"});
                table1.AddRow(new string[] {
                            "Drinks",
                            "4",
                            "2.50",
                            "2025-03-19T18:10:23.317z"});
#line 24
  testRunner.Given("Four people  group orders the following:", ((string)(null)), table1, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                            "Total"});
                table2.AddRow(new string[] {
                            "56.10"});
#line 29
  testRunner.Then("the total bill should be calculated as follows:", ((string)(null)), table2, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                            "Item",
                            "Quantity",
                            "Price",
                            "orderedTime"});
                table3.AddRow(new string[] {
                            "Starter",
                            "3",
                            "4.00",
                            "2025-03-19T18:30:23.317z"});
                table3.AddRow(new string[] {
                            "Main",
                            "3",
                            "7.00",
                            "2025-03-19T18:25:23.317z"});
                table3.AddRow(new string[] {
                            "Drinks",
                            "3",
                            "2.50",
                            "2025-03-19T18:10:23.317z"});
#line 34
  testRunner.Given("one member of the group cancels their order:", ((string)(null)), table3, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                            "Total"});
                table4.AddRow(new string[] {
                            "42.075"});
#line 39
  testRunner.Then("the final total bill should be deducted as follows:", ((string)(null)), table4, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Total bill for a group ordering starters, mains, and drinks based on order time")]
        [NUnit.Framework.TestCaseAttribute("4.00", "7.00", "2.50", "2025-03-17T17:00:00.317z", "30", "4", "4", "4", "56.10", null)]
        [NUnit.Framework.TestCaseAttribute("4.00", "7.00", "2.50", "2025-03-19T18:55:23.317z", "30", "4", "4", "4", "56.10", null)]
        [NUnit.Framework.TestCaseAttribute("4.00", "7.00", "2.50", "2025-03-20T20:09:23.317z", "0", "4", "4", "4", "59.4", null)]
        public virtual void TotalBillForAGroupOrderingStartersMainsAndDrinksBasedOnOrderTime(string eachstarter, string eachmain, string eachdrink, string orderedTime, string discountforDrinks, string starterCount, string mainCount, string drinkcount, string expectedAmount, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("eachstarter", eachstarter);
            argumentsOfScenario.Add("eachmain", eachmain);
            argumentsOfScenario.Add("eachdrink", eachdrink);
            argumentsOfScenario.Add("orderedTime", orderedTime);
            argumentsOfScenario.Add("discountforDrinks", discountforDrinks);
            argumentsOfScenario.Add("starterCount", starterCount);
            argumentsOfScenario.Add("mainCount", mainCount);
            argumentsOfScenario.Add("drinkcount", drinkcount);
            argumentsOfScenario.Add("expectedAmount", expectedAmount);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Total bill for a group ordering starters, mains, and drinks based on order time", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 45
 this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 46
    testRunner.Given(string.Format("as a restaurant owner I know the cost for {0}, {1}, and {2}", eachstarter, eachmain, eachdrink), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 47
    testRunner.When(string.Format("group of people  orders {0}, starters {1} ,mains {2}, and drinks {3}", orderedTime, starterCount, mainCount, drinkcount), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 48
    testRunner.And(string.Format("I check the {0} and apply discount on drinks if ordered within the discount time " +
                            "else discount won\'t apply", orderedTime), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 49
    testRunner.Then("the total bill should include the cost of starters, mains, and drinks along with " +
                        "<serviceCharge>", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 50
    testRunner.And(string.Format("I assert the <actualAmount> with {0}", expectedAmount), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Calculate total correct bill for group_one who orders with discount and group_two" +
            " who orders without discount")]
        public virtual void CalculateTotalCorrectBillForGroup_OneWhoOrdersWithDiscountAndGroup_TwoWhoOrdersWithoutDiscount()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Calculate total correct bill for group_one who orders with discount and group_two" +
                    " who orders without discount", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 63
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                            "Item",
                            "Quantity",
                            "Price",
                            "orderedTime"});
                table5.AddRow(new string[] {
                            "Starter",
                            "1",
                            "4.00",
                            "2025-03-19T18:30:23.317z"});
                table5.AddRow(new string[] {
                            "Main",
                            "2",
                            "7.00",
                            "2025-03-19T18:25:23.317z"});
                table5.AddRow(new string[] {
                            "Drinks",
                            "2",
                            "2.50",
                            "2025-03-19T18:10:23.317z"});
#line 64
  testRunner.Given("a First group  people orders before seven pm  following:", ((string)(null)), table5, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                            "Item",
                            "Quantity",
                            "Price",
                            "orderedTime"});
                table6.AddRow(new string[] {
                            "Starter",
                            "0",
                            "4.00",
                            "2025-03-20T20:09:23.317z"});
                table6.AddRow(new string[] {
                            "Main",
                            "2",
                            "7.00",
                            "2025-03-20T20:09:23.317z"});
                table6.AddRow(new string[] {
                            "Drinks",
                            "2",
                            "2.50",
                            "2025-03-20T20:09:23.317z"});
#line 70
  testRunner.And("a Second group people orders after  seven pm the following:", ((string)(null)), table6, "And ");
#line hidden
#line 76
  testRunner.When("I get the subtotal bill for  first and second group", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                            "expectedresult"});
                table7.AddRow(new string[] {
                            "44.55"});
#line 77
  testRunner.Then("I assert the expected result with the actual total:", ((string)(null)), table7, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
