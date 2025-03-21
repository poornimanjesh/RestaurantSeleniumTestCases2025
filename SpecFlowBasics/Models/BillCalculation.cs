namespace SpecFlowBasics.Models
{
    public class BillCalculation
    {
        // Properties
        public int Group { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }
        public decimal ServiceCharge { get; set; }
        public decimal Total { get; set; }

        // Constructor (optional)
        public BillCalculation(int group, decimal subtotal, decimal discount, decimal serviceCharge, decimal total)
        {
            Group = group;
            Subtotal = subtotal;
            Discount = discount;
            ServiceCharge = serviceCharge;
            Total = total;
        }

        // Default constructor (required for SpecFlow table binding)
        public BillCalculation() { }

        // Override ToString for better readability (optional)
        public override string ToString()
        {
            return $"Group: {Group}, Subtotal: {Subtotal}, Discount: {Discount}, ServiceCharge: {ServiceCharge}, Total: {Total}";
        }
    }


}
