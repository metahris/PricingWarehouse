namespace PricingWarehouse.Domain
{
    public class Currency
    {
        public string Value { get; private set; }
        public Currency(string value)
        {
            Value = value;
        }
    }
}
