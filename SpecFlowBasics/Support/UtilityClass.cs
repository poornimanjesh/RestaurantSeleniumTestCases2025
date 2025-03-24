using SpecFlowBasics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace RestaurantTestsSpecFlow.Support
{
    public class UtilityClass
    {
        public static Order UpdateOrder(Table table, Order order)
        {
            DateTime orderedTime = DateTime.Now;

            foreach (var row in table.Rows)
            {
                var item = row["Item"];
                var quantity = int.Parse(row["Quantity"]);
                var price = decimal.Parse(row["Price"]);
                orderedTime = DateTime.Parse(row["orderedTime"]);
                order.MenuItems.Add(new MenuItem() { IsUpdate = false, Name = item, Price = price, Quantity = quantity });
            }
            order.OrderTime = orderedTime;
            return order;
        }
    }
}
