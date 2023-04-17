namespace PricingWarehouse.Domain
{
    public class Delta
    {
        public double Value { get; private set; }
        public Delta(double value)
        {
            Value = value;
        }
    }
}
