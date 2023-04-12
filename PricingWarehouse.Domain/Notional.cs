namespace PricingWarehouse.Domain
{
    public class Notional
    {
        public double Value { get; private set; }
        public Notional(double value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Notional can't be lesser than 0");
            }
            Value = value;
        }
    }
}
