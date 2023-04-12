namespace PricingWarehouse.Domain
{
    public class EndDate
    {
        public DateTime Value { get; private set; }
        public EndDate(DateTime value)
        {
            if (value < DateTime.Today)
                throw new ArgumentException("end date can't be lesser than today");
            Value = value;
        }
    }
}
