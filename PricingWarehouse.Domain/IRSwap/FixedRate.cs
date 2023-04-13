namespace PricingWarehouse.Domain.IRSwap
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
