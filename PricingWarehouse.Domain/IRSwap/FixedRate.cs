namespace PricingWarehouse.Domain.IRSwap
{
    public class FixedRate
    {
        public string Value { get; private set; }
        public FixedRate(string value)
        {
            Value = value;
        }
    }
}
