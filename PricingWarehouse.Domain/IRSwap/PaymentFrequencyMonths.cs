namespace PricingWarehouse.Domain
{
    public class PaymentFrequencyMonths
    {
        public int Value { get; private set; }
        public PaymentFrequencyMonths(int value)
        {
            Value = value;
        }
    }
}
