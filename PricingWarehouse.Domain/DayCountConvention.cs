namespace PricingWarehouse.Domain
{
    public class DayCountConvention
    {
        public string Value { get; private set; }
        public DayCountConvention(string value)
        {
            Value = value;
        }
    }
}
