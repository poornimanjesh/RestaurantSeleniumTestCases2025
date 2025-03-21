using Conferma.API.Framework;
using Newtonsoft.Json;
using NUnit.Framework;
using SpecFlowBasics.Models;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace SpecFlowBasics.StepDefinitions
{
    [Binding]
    public class CalculateTotalBillForCancelOrderStepDefinitions
    {

        private List<OrderItem> _orderItems;
        Order order = null;
        Helper helper;
        decimal total;
        private List<BillCalculation> _billCalculations;
        private readonly FeatureContext _featureContext;
        private List<ExpectedResult> _expectedResults;

        public CalculateTotalBillForCancelOrderStepDefinitions(FeatureContext featureContext)
        {
            _featureContext = featureContext;
            helper = new Helper();
        }

        [Given(@"Four people  group orders the following:")]
        public void GivenFourPeopleGroupOrdersTheFollowing(Table table5)
        {
            order = new Order();
            order.ServiceCharge = 10;
            order.Number = 3;
            order.MenuItems = new List<MenuItem>();
            _orderItems = new List<OrderItem>();
            DateTime orderedTime = DateTime.Now;
            foreach (var row in table5.Rows)
            {
                var item = row["Item"];
                var quantity = int.Parse(row["Quantity"]);
                var price = decimal.Parse(row["Price"]);
                orderedTime = DateTime.Parse(row["orderedTime"]);

                _orderItems.Add(new OrderItem(item, quantity, price, orderedTime));
                order.MenuItems.Add(new MenuItem() { IsUpdate = false, Name = item, Price = price, Quantity = quantity });
            }
            order.OrderTime = orderedTime;
            string baseUrl = "http://localhost:5049/api/";
            var client = helper.SetUrl(baseUrl, "Restaurent");
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
            _orderItems = new List<OrderItem>();

            foreach (var row in table.Rows)
            {
                var item = row["Item"];
                var quantity = int.Parse(row["Quantity"]);
                var price = decimal.Parse(row["Price"]);
                var orderedTime = DateTime.Parse(row["orderedTime"]);
                order.OrderTime = orderedTime;
                _orderItems.Add(new OrderItem(item, quantity, price, orderedTime));
                order.MenuItems.Add(new MenuItem() { IsUpdate = false, Name = item, Price = price, Quantity = quantity });

            }
            order.IsUpdate = true;
            string baseUrl = "http://localhost:5049/api/";
            //var id = 
            var client = helper.SetUrl(baseUrl, "Restaurent/3");
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

            //  Print the expected results for verification
            foreach (var expectedResult in _expectedResults)
            {
                Console.WriteLine(expectedResult.ToString());
            }

            // Example assertion (replace with your actual assertion logic)
            //var actualTotal = 44.55m; // Replace this with your actual total calculation
            //actualTotal = Convert.ToDecimal(_featureContext["temptotal4"]) + Convert.ToDecimal(_featureContext["temptotal2"]);
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

            //  Print the expected results for verification
            foreach (var expectedResult in _expectedResults)
            {
                Console.WriteLine(expectedResult.ToString());
            }

            // Example assertion (replace with your actual assertion logic)
            //var actualTotal = 44.55m; // Replace this with your actual total calculation
            //actualTotal = Convert.ToDecimal(_featureContext["temptotal8"]) + Convert.ToDecimal(_featureContext["temptotal2"]);
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