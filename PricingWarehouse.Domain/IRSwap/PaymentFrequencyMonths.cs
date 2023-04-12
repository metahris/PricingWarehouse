namespace PricingWarehouse.Domain.IRSwap
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
