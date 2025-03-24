using SpecFlowBasics.Models;
using TechTalk.SpecFlow;
using Conferma.API.Framework;
using Newtonsoft.Json;
using NUnit.Framework;
using RestaurantTestsSpecFlow.Support;

namespace SpecFlowBasics.StepDefinitions
{
    [Binding]
    public class GenarateBillBasedOnTimeStepDefinitions: BaseDefenition
    {

      private List<OrderItem> _orderItems;
        Order order = null;
        Helper helper;
        decimal total;
        private List<BillCalculation> _billCalculations;
        private readonly FeatureContext _featureContext;

        public GenarateBillBasedOnTimeStepDefinitions(FeatureContext featureContext)
        {
            _featureContext = featureContext;
            helper = new Helper();
        }

        [Given(@"a First group  people orders before seven pm  following:")]
        public void GivenAFirstGroupPeopleOrdersBeforeSevenPmFollowing(Table table)
        {
            DateTime orderedTime = DateTime.Now;
            order = new Order();
            order.ServiceCharge = 10;
            order.Number = 2;
            order.MenuItems = new List<MenuItem>();
            UtilityClass.UpdateOrder(table, order);    
            var client = helper.SetUrl(baseUrl, "Restaurant");
            var orders = new Orders();
            orders.OrderList = new List<Order>();
            orders.OrderList.Add(order);
            //var json = JsonConvert.SerializeObject(orders);//debugging
            var request = helper.CreatePostRequest(orders);
            var response = helper.GetResponseAsync(client, request).Result;
            total = Convert.ToDecimal(response.Content);
            _featureContext["temptotal1"] = total;

        }


        [Given(@"a Second group people orders after  seven pm the following:")]
        public void GivenASecondGroupPeopleOrdersAfterSevenPmTheFollowing(Table table)
        {
            order = new Order();
            order.ServiceCharge = 10;
            order.MenuItems = new List<MenuItem>();
            
            UtilityClass.UpdateOrder(table, order);
            order.IsUpdate = true;

            var client = helper.SetUrl(baseUrl, "Restaurant/2");
            var orders = new Orders();
            orders.OrderList = new List<Order>();
            orders.OrderList.Add(order);
           // var json = JsonConvert.SerializeObject(orders);//debugging
            var request = helper.CreatePutRequest(order);
            var response = helper.GetResponseAsync(client, request).Result;
            decimal total2 = Convert.ToDecimal(response.Content);
            _featureContext["temptotal2"] = total2;
        }

        [When(@"I get the subtotal bill for  first and second group")]
        public void WhenIGetTheSubtotalBillForFirstAndSecondGroup()
        {
           
        }

       
        private List<ExpectedResult> _expectedResults;

        [Then(@"I assert the expected result with the actual total:")]
        public void ThenIAssertTheExpectedResultWithTheActualTotal(Table table4)
        {
            _expectedResults = new List<ExpectedResult>();

            foreach (var row in table4.Rows)
            {
                var expectedResult = decimal.Parse(row["expectedresult"]);

                _expectedResults.Add(new ExpectedResult(expectedResult));
            }

            decimal actualTotal = Convert.ToDecimal(_featureContext["temptotal1"]) + Convert.ToDecimal(_featureContext["temptotal2"]);
            var expectedTotal = _expectedResults[0].ExpectedResults; // Assuming only one row in the table
            
            Assert.AreEqual(actualTotal, expectedTotal);

            if (actualTotal == expectedTotal)
            {
                Console.WriteLine("Assertion passed: Expected total matches actual total.");
            }
            else
            {
                Console.WriteLine($"Assertion failed: Expected {expectedTotal}, but got {actualTotal}.");
            }
        }
    }
}
