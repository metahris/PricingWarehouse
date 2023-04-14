using PricingWarehouse.Domain.IRSwap;
using PricingWarehouse.Domain.Product;

namespace PricingWarehouse.Domain.Swaption
{
    public interface ISwaptionBuilder<T>: IProductBuilder<T> where T : IOption
    {
        void AddOptionType(OptionType optionType);
        void AddSettlementType(SettlementType settlementType);
        void AddValuationDate(DateTime valuationDate);
        void AddOptionEffectiveDate(DateTime optionEffectiveDate);
        void AddOptionExpirationDate(DateTime optionExpirationDate);
        void AddOptionPrice(double optionPrice);
        void AddPricingModel(PricingModel pricingModel);
        void AddUnderlyingSwap(double fixedRate, string floatingRateReference, double floatingRateSpread, int paymentFrequencyMonths, double swapValue, string currency,
            string dayCountConvention, DateTime startDate, DateTime endDate, double notional, DateTime valuationDate, IRSwapBuilder irSwapBuilder);
    }
    public class EuropeanSwaptionBuilder:ISwaptionBuilder<ISwaption>
    {
        private OptionType optionType;
        private SettlementType settlementType;
        private ValuationDate optionValuationDate;
        private StartDate optionEffectiveDate;
        private EndDate optionExpirationDate;
        private OptionPrice optionPrice;
        private PricingModel pricingModel;
        private IIRSwap underlyingSwap;

        public void AddOptionEffectiveDate(DateTime optionEffectiveDate)
        {
            this.optionEffectiveDate = new StartDate(optionEffectiveDate);
        }

        public void AddOptionExpirationDate(DateTime optionExpirationDate)
        {
            this.optionExpirationDate = new EndDate(optionExpirationDate);
        }

        public void AddOptionPrice(double optionPrice)
        {
            this.optionPrice = new OptionPrice(optionPrice);
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
        public void AddUnderlyingSwap(double fixedRate, string floatingRateReference, double floatingRateSpread, int paymentFrequencyMonths, double swapValue, string currency,
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
            irSwapBuilder.AddSwapValue(swapValue);

            this.underlyingSwap = irSwapBuilder.Build();
        }

        public ISwaption Build()
        {
            return new EuropeanSwaption(optionType, settlementType, optionValuationDate, optionEffectiveDate, optionExpirationDate,
                optionPrice, pricingModel,underlyingSwap);
        }
    }
}
