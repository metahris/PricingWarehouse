namespace PricingWarehouse.Domain
{
    public class EuropeanSwaptionBuilder:IProductBuilder<EuropeanSwaption>
    {
        private OptionType optionType;
        private SettlementType settlementType;
        private ValuationDate optionValuationDate;
        private StartDate optionEffectiveDate;
        private EndDate optionExpirationDate;
        private Price price;
        private PricingModel pricingModel;
        private IRSwap underlyingSwap;

        private Delta delta;
        private Gamma gamma;
        private Vega vega;

        public void AddOptionEffectiveDate(DateTime optionEffectiveDate)
        {
            this.optionEffectiveDate = new StartDate(optionEffectiveDate);
        }

        public void AddOptionExpirationDate(DateTime optionExpirationDate)
        {
            this.optionExpirationDate = new EndDate(optionExpirationDate);
        }

        public void AddPrice(double price)
        {
            this.price = new Price(price);
        }

        public void AddOptionType(OptionType optionType)
        {
            this.optionType = optionType;
        }

        public void AddPricingModel(PricingModel pricingModel)
        {
            this.pricingModel = pricingModel;
        }

        public void AddSettlementType(SettlementType settlementType)
        {
            this.settlementType = settlementType;
        }
        public void AddValuationDate(DateTime valuationDate)
        {
            this.optionValuationDate = new ValuationDate(valuationDate);
        }
        public void AddUnderlyingSwap(double fixedRate, string floatingRateReference, double floatingRateSpread, int paymentFrequencyMonths, double price, string currency,
            string dayCountConvention, DateTime startDate, DateTime endDate, double notional, DateTime valuationDate, IRSwapBuilder irSwapBuilder)
        {
            irSwapBuilder.AddFixedRate(fixedRate);
            irSwapBuilder.AddFloatingRateReference(floatingRateReference);
            irSwapBuilder.AddCurrency(currency);
            irSwapBuilder.AddDayCountConvention(dayCountConvention);
            irSwapBuilder.AddValuationDate(valuationDate);
            irSwapBuilder.AddStartDate(startDate);
            irSwapBuilder.AddEndDate(endDate);
            irSwapBuilder.AddNotional(notional);
            irSwapBuilder.AddFloatingRateSpread(floatingRateSpread);
            irSwapBuilder.AddPaymentFrequencyMonths(paymentFrequencyMonths);
            irSwapBuilder.AddPrice(price);

            this.underlyingSwap = irSwapBuilder.Build();
        }

        public void AddDelta(double delta)
        {
            if (delta < 0 || delta > 1)
            {
                throw new ArgumentOutOfRangeException("delta must be between 0 and 1");
            }
            this.vega = new Vega(delta);
        }
        public void AddGamma(double gamma)
        {
            this.gamma = new Gamma(gamma);
        }

        public void AddVega(double vega)
        {
            this.vega = new Vega(vega);
        }

        public EuropeanSwaption Build()
        {
            return new EuropeanSwaption(optionType, settlementType, optionValuationDate, optionEffectiveDate, optionExpirationDate,
                price, pricingModel,underlyingSwap, delta, gamma, vega);
        }
    }
}
