
using PricingWarehouse.DAO;
using PricingWarehouse.Domain.IRSwap;

namespace PricingWarehouse.Repository
{
    public class IRSwapRepository : IProductRepository<IIRSwap>
    {
        private readonly IIRSwapDAO _irSwapDAO;
        private readonly IRSwapBuilder _irSwapBuilder;
        public IRSwapRepository(IIRSwapDAO irSwapDAO, IRSwapBuilder irSwapBuilder)
        {
            _irSwapDAO = irSwapDAO;
            _irSwapBuilder = irSwapBuilder;    
        }
        public int InsertProduct(IIRSwap irSwap)
        {
            var irSwapDTO = new IRSwapDTO
            {
                Currency = irSwap.Currency.Value,
                Notional = irSwap.Notional.Value,
                FixedRate = irSwap.FixedRate.Value,
                FloatingRateReference = irSwap.FloatingRateReference.Value,
                FloatingRateSpread = irSwap.FloatingRateSpread.Value,
                DayCountConvention = irSwap.DayCountConvention.Value,
                PaymentFrequencyMonths = irSwap.PaymentFrequencyMonths.Value,
                ValuationDate = irSwap.ValuationDate.Value,
                StartDate = irSwap.StartDate.Value,
                EndDate = irSwap.EndDate.Value,
                SwapValue = irSwap.SwapValue.Value,
            };
            return _irSwapDAO.InsertIRSwap(irSwapDTO);
        }

        public IIRSwap GetProductById(int irSwapId)
        {
            var irSwapDTO = _irSwapDAO.GetIRSwapById(irSwapId);
            _irSwapBuilder.AddFixedRate(irSwapDTO.FixedRate);
            _irSwapBuilder.AddFloatingRateReference(irSwapDTO.FloatingRateReference);
            _irSwapBuilder.AddFloatingRateSpread(irSwapDTO.FloatingRateSpread);
            _irSwapBuilder.AddCurrency(irSwapDTO.Currency);
            _irSwapBuilder.AddDayCountConvention(irSwapDTO.DayCountConvention);
            _irSwapBuilder.AddPaymentFrequencyMonths(irSwapDTO.PaymentFrequencyMonths);
            _irSwapBuilder.AddStartDate(irSwapDTO.StartDate);
            _irSwapBuilder.AddEndDate(irSwapDTO.EndDate);
            _irSwapBuilder.AddValuationDate(irSwapDTO.ValuationDate);
            _irSwapBuilder.AddNotional(irSwapDTO.Notional);
            _irSwapBuilder.AddSwapValue(irSwapDTO.SwapValue);
            return _irSwapBuilder.Build();

        }
    }
}