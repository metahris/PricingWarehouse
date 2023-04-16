namespace PricingWarehouse.Domain
{
    public class Price
    {
        public double Value { get; set; }
        public Price(double value)
        {
            if (Value < 0)
            {
                throw new ArgumentException("Price can't be negative");
            }
            Value = value;
        }
    }
}
