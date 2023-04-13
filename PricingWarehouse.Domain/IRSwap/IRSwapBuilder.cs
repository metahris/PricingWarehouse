using PricingWarehouse.Domain.Product;

namespace PricingWarehouse.Domain.IRSwap
{
    public interface IIRSwapBuilder: IProductBuilder
    {
        void AddFixedRate(double fixedRate);
        void AddFloatingRateReference(string floatingRateReference);
        void AddFloatingRateSpread(double floatingRateSpread);
        void AddPSwapValue(double swapValue);
        void AddCurrency(string currency);
        void AddDayCountConvention(string dayCountConvention);
        void AddStartDate(DateTime startDate);
        void AddEndDate(DateTime endDate);
        void AddValuationDate(DateTime valuationDate);
        void AddNotional(double notional);
        void AddOptionPrice(double optionPrice);
    }
    public class IRSwapBuilder:IIRSwapBuilder
    {
        private FixedRate fixedRate;
        private FloatingRateReference floatingRateReference;
        private FloatingRateSpread floatingRateSpread;
        private PaymentFrequencyMonths paymentFrequencyMonths;
        private SwapValue swapValue;
        private Currency currency;
        private DayCountConvention dayCountConvention;
        private StartDate startDate;
        private EndDate endDate;
        private Notional notional;
        private ValuationDate valuationDate;
        private OptionPrice optionPrice;


        public void AddCurrency(string currency)
        {
            this.currency = new Currency(currency);
        }

        public void AddDayCountConvention(string dayCountConvention)
        {
            this.dayCountConvention = new DayCountConvention(dayCountConvention);
        }

        public void AddEndDate(DateTime endDate)
        {
            this.endDate = new EndDate(endDate);
        }

        public void AddFixedRate(double fixedRate)
        {
            this.fixedRate = new FixedRate(fixedRate);
        }

        public void AddFloatingRateReference(string floatingRateReference)
        {
            this.floatingRateReference = new FloatingRateReference(floatingRateReference);
        }

        public void AddFloatingRateSpread(double floatingRateSpread)
        {
            this.floatingRateSpread = new FloatingRateSpread(floatingRateSpread);
        }

        public void AddNotional(double notional)
        {
            this.notional = new Notional(notional);
        }

        public void AddOptionPrice(double optionPrice)
        {
            this.optionPrice = new OptionPrice(optionPrice);
        }

        public void AddPSwapValue(double swapValue)
        {
            this.swapValue = new SwapValue(swapValue);
        }

        public void AddStartDate(DateTime startDate)
        {
            this.startDate = new StartDate(startDate);
        }

        public void AddValuationDate(DateTime valuationDate)
        {
            this.valuationDate = new ValuationDate(valuationDate);
        }

        public IProduct Build()
        {
            return new IRSwap(fixedRate,  floatingRateReference,  floatingRateSpread,paymentFrequencyMonths,  swapValue,  currency,  dayCountConvention,
             startDate,  endDate,  notional,  valuationDate);
        }
    }
}
