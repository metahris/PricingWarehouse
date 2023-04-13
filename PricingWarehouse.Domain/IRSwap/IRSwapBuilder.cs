using PricingWarehouse.Domain.Product;

namespace PricingWarehouse.Domain.IRSwap
{
    public interface IIRSwapBuilder<T>: IProductBuilder<T> where T : IProduct
    {
        void AddFixedRate(double fixedRate);
        void AddFloatingRateReference(string floatingRateReference);
        void AddFloatingRateSpread(double floatingRateSpread);
        void AddCurrency(string currency);
        void AddDayCountConvention(string dayCountConvention);
        void AddPaymentFrequencyMonths(int paymentFrequencyMonths);
        void AddStartDate(DateTime startDate);
        void AddEndDate(DateTime endDate);
        void AddValuationDate(DateTime valuationDate);
        void AddNotional(double notional);
        void AddSwapValue(double swapValue);
    }
    public class IRSwapBuilder:IIRSwapBuilder<IIRSwap> 
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


        public void AddCurrency(string currency)
        {
            this.currency = new Currency(currency);
        }

        public void AddDayCountConvention(string dayCountConvention)
        {
            this.dayCountConvention = new DayCountConvention(dayCountConvention);
        }
        public void AddPaymentFrequencyMonths(int paymentFrequencyMonths)
        {
            this.paymentFrequencyMonths = new PaymentFrequencyMonths(paymentFrequencyMonths);
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

        public void AddSwapValue(double swapValue)
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
        public IIRSwap Build()
        {
            return new IRSwap(fixedRate, floatingRateReference, floatingRateSpread, paymentFrequencyMonths, swapValue, currency, dayCountConvention,
             startDate, endDate, notional, valuationDate);
        }
    }
}
