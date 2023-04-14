namespace PricingWarehouse.Domain
{
    public class FixedRate
    {
        public double Value { get; private set; }
        public FixedRate(double value)
        {
            Value = value;
        }
    }
}
