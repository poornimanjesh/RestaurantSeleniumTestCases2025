using SpecFlowBasics.Models;
using TechTalk.SpecFlow;
using Conferma.API.Framework;
using Newtonsoft.Json;

namespace SpecFlowBasics.StepDefinitions
{
    [Binding]
    public class GenarateBillBasedOnTime: BaseDefenition
    {

      private List<OrderItem> _orderItems;
        Order order = null;
        Helper helper;
        decimal total;
        private List<BillCalculation> _billCalculations;
        private readonly FeatureContext _featureContext;

        public GenarateBillBasedOnTime(FeatureContext featureContext)
        {
            _featureContext = featureContext;
            helper = new Helper();
        }

        [Given(@"a First group  people orders before seven pm  following:")]
        public void GivenAFirstGroupPeopleOrdersBeforeSevenPmFollowing(Table table)
        {

            order = new Order();
            order.ServiceCharge = 10;
            order.Number = 2;
            order.MenuItems = new List<MenuItem>();
            _orderItems = new List<OrderItem>();

            foreach (var row in table.Rows)
            {
                var item = row["Item"];
                var quantity = int.Parse(row["Quantity"]);
                var price = decimal.Parse(row["Price"]);
                var orderedTime = DateTime.Parse(row["orderedTime"]);

                _orderItems.Add(new OrderItem(item, quantity, price, orderedTime));
                order.MenuItems.Add(new MenuItem() { IsUpdate = false, Name = item, Price = price, Quantity = quantity });
            }

           // string baseUrl = "http://localhost:5049/api/";
            var client = helper.SetUrl(baseUrl, "Restaurant");
            var orders = new Orders();
            orders.OrderList = new List<Order>();
            orders.OrderList.Add(order);
            var json = JsonConvert.SerializeObject(orders);
            var request = helper.CreatePostRequest(orders);
            var response = helper.GetResponseAsync(client, request).Result;
            total = Convert.ToDecimal(response.Content);
            _featureContext["temptotal"] = total;

        }


        [Given(@"a Second group people orders after  seven pm the following:")]
        public void GivenASecondGroupPeopleOrdersAfterSevenPmTheFollowing(Table table2)
        {
            order = new Order();
            order.ServiceCharge = 10;
            order.MenuItems = new List<MenuItem>();
            _orderItems = new List<OrderItem>();

            foreach (var row in table2.Rows)
            {
                var item = row["Item"];
                var quantity = int.Parse(row["Quantity"]);
                var price = decimal.Parse(row["Price"]);
                var orderedTime = DateTime.Parse(row["orderedTime"]);

                _orderItems.Add(new OrderItem(item, quantity, price, orderedTime));
                order.MenuItems.Add(new MenuItem() { IsUpdate = false, Name = item, Price = price, Quantity = quantity });

            }
           // string baseUrl = "http://localhost:5049/api/";
            var client = helper.SetUrl(baseUrl, "Restaurant/2");
            var orders = new Orders();
            orders.OrderList = new List<Order>();
            orders.OrderList.Add(order);
           // var json = JsonConvert.SerializeObject(orders);
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

            //  Print the expected results for verification
            foreach (var expectedResult in _expectedResults)
            {
                Console.WriteLine(expectedResult.ToString());
            }

            // Example assertion (replace with your actual assertion logic)
            var actualTotal = 44.55m; // Replace this with your actual total calculation
            actualTotal = Convert.ToDecimal(_featureContext["temptotal2"]) + Convert.ToDecimal(_featureContext["temptotal2"]);
            var expectedTotal = _expectedResults[0].ExpectedResults; // Assuming only one row in the table

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
