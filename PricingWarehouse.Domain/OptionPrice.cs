namespace PricingWarehouse.Domain
{
    public class OptionPrice
    {
        public double Value { get; set; }
        public OptionPrice(double value)
        {
            if (Value < 0)
            {
                throw new ArgumentException("Price can't be negative");
            }
            Value = value;
        }
    }
}
