namespace PricingWarehouse.Domain
{
    public class IRSwap:IProduct
    {
        public FixedRate FixedRate { get; private set; }
        public FloatingRateReference FloatingRateReference { get; private set; }
        public FloatingRateSpread FloatingRateSpread { get; private set; }
        public PaymentFrequencyMonths PaymentFrequencyMonths { get; private set; }
        public Price Price { get; private set; }
        public Currency Currency { get; private set; }
        public DayCountConvention DayCountConvention { get; private set; }
        public StartDate StartDate { get; private set; }
        public EndDate EndDate { get; private set; }
        public Notional Notional { get; private set; }
        public ValuationDate ValuationDate { get; private set; }
        public int Id { get; private set; } 
        public IRSwap(FixedRate fixedRate, FloatingRateReference floatingRateReference, FloatingRateSpread floatingRateSpread,
            PaymentFrequencyMonths paymentFrequencyMonths, Price price, Currency currency, DayCountConvention dayCountConvention,
            StartDate startDate, EndDate endDate, Notional notional, ValuationDate valuationDate)
        {
            FixedRate = fixedRate;
            FloatingRateReference = floatingRateReference;
            FloatingRateSpread = floatingRateSpread;
            PaymentFrequencyMonths = paymentFrequencyMonths;
            Price = price;
            Currency = currency;
            DayCountConvention = dayCountConvention;
            StartDate = startDate;
            EndDate = endDate;
            Notional = notional;
            ValuationDate = valuationDate;
        }

        public void SetPrice(double price)
        {
            if (Price == null)
            {
                Price = new Price(price);
            }
            else
            {
                Price.Value = price;
            }
        }
        public void SetId(int id)
        {
            Id = id;
        }
    }
}
