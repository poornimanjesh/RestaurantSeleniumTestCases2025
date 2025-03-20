using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowBasics.Models
{
    using System;

    public class OrderItem
    {
       // // Properties
       // public string Item { get; set; }
       // public int Quantity { get; set; }
       // public DateTime OrderedTime { get; set; }
       //
       // // Constructor (optional)
       // public OrderItem(string item, int quantity, DateTime orderedTime)
       // {
       //     Item = item;
       //     Quantity = quantity;
       //     OrderedTime = orderedTime;
       // }
       //
       // // Default constructor (required for SpecFlow table binding)
       // public OrderItem() { }
       //
       // // Override ToString for better readability (optional)
       // public override string ToString()
       // {
       //     return $"Item: {Item}, Quantity: {Quantity}, OrderedTime: {OrderedTime}";
       // }

        // Properties
        public string Item { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderedTime { get; set; }

        // Constructor (optional)
        public OrderItem(string item, int quantity, decimal price, DateTime orderedTime)
        {
            Item = item;
            Quantity = quantity;
            Price = price;
            OrderedTime = orderedTime;
        }

        // Default constructor (required for SpecFlow table binding)
        public OrderItem() { }

        // Override ToString for better readability (optional)
        public override string ToString()
        {
            return $"Item: {Item}, Quantity: {Quantity}, Price: {Price}, OrderedTime: {OrderedTime}";
        }
    }


}