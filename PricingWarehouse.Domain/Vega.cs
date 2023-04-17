namespace PricingWarehouse.Domain
{
    public class Vega
    {
        public double Value { get; private set; }
        public Vega(double value)
        {
            Value = value;
        }
    }
}
