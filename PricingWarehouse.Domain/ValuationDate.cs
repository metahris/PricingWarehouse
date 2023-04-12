namespace PricingWarehouse.Domain
{
    public class ValuationDate
    {
        public DateTime Value { get; private set; }
        public ValuationDate(DateTime value)
        {
            Value = value;
        }
    }
}
