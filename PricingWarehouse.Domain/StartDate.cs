namespace PricingWarehouse.Domain
{
    public class StartDate
    {
        public DateTime Value { get; private set; }
        public StartDate(DateTime value)
        {
            Value = value;
        }
    }
}
