using Conferma.API.Framework;
using Newtonsoft.Json;
using NUnit.Framework;
using RestaurantTestsSpecFlow.Support;
using SpecFlowBasics.Models;
using System.Net;
using TechTalk.SpecFlow;

namespace SpecFlowBasics.StepDefinitions
{
    [Binding]
    public class CalculateTotalBillForCancelOrderStepDefinitions:BaseDefenition
    {

        private List<OrderItem> _orderItems;
        Order order = null;
        Helper helper;
        decimal total;
        private List<BillCalculation> _billCalculations;
        private readonly FeatureContext _featureContext;
        private List<ExpectedResult> _expectedResults;
        //public string baseUrl = "http://localhost:5049/api/";
        public CalculateTotalBillForCancelOrderStepDefinitions(FeatureContext featureContext)
        {
            _featureContext = featureContext;
            helper = new Helper();
        }

        [Given(@"Four people  group orders the following:")]
        public void GivenFourPeopleGroupOrdersTheFollowing(Table table)
        {
            order = new Order();
            order.ServiceCharge = 10;
            order.Number = 3;
            order.MenuItems = new List<MenuItem>();
            UtilityClass.UpdateOrder(table, order);
            var client = helper.SetUrl(baseUrl, "Restaurant");
            var orders = new Orders();
            orders.OrderList = new List<Order>();
            orders.OrderList.Add(order);
            var json = JsonConvert.SerializeObject(orders);
            var request = helper.CreatePostRequest(orders);
            var response = helper.GetResponseAsync(client, request).Result;
            total = Convert.ToDecimal(response.Content);
            _featureContext["temptotal3"] = total;

        }


        [Given(@"one member of the group cancels their order:")]
        public void GivenOneMemberOfTheGroupCancelsTheirOrder(Table table)
        {
            order = new Order();
            order.ServiceCharge = 10;
            order.MenuItems = new List<MenuItem>();
            
            UtilityClass.UpdateOrder(table,order);

            order.IsUpdate = true;
            //string baseUrl = "http://localhost:5049/api/";
            //var id = 
            var client = helper.SetUrl(baseUrl, "Restaurant/3");
            var orders = new Orders();
            orders.OrderList = new List<Order>();
            orders.OrderList.Add(order);
            // var json = JsonConvert.SerializeObject(orders);
            var request = helper.CreatePutRequest(order);
            var response = helper.GetResponseAsync(client, request).Result;
            decimal total2 = Convert.ToDecimal(response.Content);
            _featureContext["temptotal4"] = total2;

            Assert.AreEqual( HttpStatusCode.OK , response.StatusCode);
        }


        [Then(@"the total bill should be calculated as follows:")]
        public void ThenTheTotalBillShouldBeCalculatedAsFollows(Table table6)
        {
            _expectedResults = new List<ExpectedResult>();

            foreach (var row in table6.Rows)
            {
                var expectedResult = decimal.Parse(row["Total"]);

                _expectedResults.Add(new ExpectedResult(expectedResult));
            }
                      

            var expectedTotal = _expectedResults[0].ExpectedResults; // Assuming only one row in the table

            decimal actualTotal = Convert.ToDecimal(_featureContext["temptotal3"]);

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


        [Then(@"the final total bill should be deducted as follows:")]
        public void ThenTheFinalTotalBillShouldBeDeductedAsFollows(Table table8)
        {
            _expectedResults = new List<ExpectedResult>();

            foreach (var row in table8.Rows)
            {
                var expectedResult = decimal.Parse(row["Total"]);

                _expectedResults.Add(new ExpectedResult(expectedResult));
            }
           
            var expectedTotal = _expectedResults[0].ExpectedResults; // Assuming only one row in the table

            decimal actualTotal = Convert.ToDecimal(_featureContext["temptotal4"]);

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