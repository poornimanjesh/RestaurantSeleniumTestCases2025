using Conferma.API.Framework;
using Newtonsoft.Json;
using NUnit.Framework;
using SpecFlowBasics.Models;
using System.Net;
using TechTalk.SpecFlow;

namespace SpecFlowBasics.StepDefinitions
{
    public class BaseDefenition
    {
        public string baseUrl = "http://localhost:5049/api/";
    }

    [Binding]
    public class checkoutSystemForRestaurant_Step_def: BaseDefenition
    {
        Order order;
        decimal total;
        Helper helper;
       // private string baseUrl = "http://localhost:5049/api/";

        public checkoutSystemForRestaurant_Step_def()
        {
            helper  = new Helper();
        }

        [Given(@"as a restaurant owner I know the cost for (.*), (.*), and (.*)")]
        public void GivenAsARestaurantOwnerIKnowTheCostForAnd(Decimal starterPrice, Decimal mainPrice, Decimal drinksPrice)
        {
          
                    }

        [When(@"group of people  orders (.*), starters (.*) ,mains (.*), and drinks (.*)")]
        public void WhenGroupOfPeopleOrdersStartersMainsAndDrinks(string ordertime, int startercount, int mainCount, int drinkscount)
        {
            order = new Order();
            order.ServiceCharge = 10;
            order.OrderTime = Convert.ToDateTime(ordertime);
            order.MenuItems = new List<MenuItem>();
            order.MenuItems.Add(new MenuItem() { IsUpdate = false, Name = "Starter", Price=4 , Quantity = startercount });
            order.MenuItems.Add(new MenuItem() { IsUpdate = false, Name = "Main",Price = 7, Quantity = mainCount });
            order.MenuItems.Add(new MenuItem() { IsUpdate = false, Name = "Drinks",  Price = 2.5M,  Quantity = drinkscount });
        }


        [When(@"I check the (.*) and apply discount on drinks if ordered within the discount time else discount won't apply")]
        public void WhenICheckTheAndApplyDiscountOnDrinksIfOrderedWithinTheDiscountTimeElseDiscountWontApply(string orderTime)
        {
            DateTime ordertimedt = Convert.ToDateTime(orderTime);
            bool isDiscountEligible = Restaurant.IsOrderEligebleForDiscount(ordertimedt);
            if (ordertimedt.Hour < 19)
                Assert.IsTrue(isDiscountEligible);
            else
                Assert.IsFalse(isDiscountEligible);
        }


        [Then(@"total bill should include the cost of starters, mains, and drinks along with ServiceCharge")]
        public void ThenTotalBillShouldIncludeTheCostOfStartersMainsAndDrinksAlongWithServiceCharge()
        {
           
        }



        [Then(@"the total bill should include the cost of starters, mains, and drinks along with <serviceCharge>")]
        public void ThenTheTotalBillShouldIncludeTheCostOfStartersMainsAndDrinksAlongWithServiceCharge()
        {
            var client = helper.SetUrl(baseUrl, "Restaurant");
            var orders = new Orders();
            orders.OrderList = new List<Order>();
            orders.OrderList.Add(order);
            var json = JsonConvert.SerializeObject(orders);
            var request = helper.CreatePostRequest(orders);
            var response = helper.GetResponseAsync(client, request).Result;
            total = Convert.ToDecimal(response.Content);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.That(response.ContentType, Is.EqualTo("application/json"));
        }

        [Then(@"I assert the <actualAmount> with (.*)")]
        public void ThenIAssertTheActualAmountWith(Decimal expectedresult)
        {
           // var total = Restaurant.CalculateTotal(order);
            Assert.AreEqual(expectedresult, total);

        }




    }
}
