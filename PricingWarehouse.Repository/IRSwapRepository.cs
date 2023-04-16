using PricingWarehouse.DAO;
using PricingWarehouse.Domain;
using PricingWarehouse.DTO;

namespace PricingWarehouse.Repository
{
    public class IRSwapRepository : IProductRepository<IRSwap>
    {
        private readonly IRSwapDAO _irSwapDAO;
        private readonly IRSwapBuilder _irSwapBuilder;
        public IRSwapRepository(IRSwapDAO irSwapDAO, IRSwapBuilder irSwapBuilder)
        {
            _irSwapDAO = irSwapDAO;
            _irSwapBuilder = irSwapBuilder;    
        }
        public int InsertProduct(IRSwap irSwap)
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
                Price = irSwap.Price.Value,
            };
            return _irSwapDAO.InsertProduct(irSwapDTO);
        }

        public IRSwap GetProductById(int irSwapId)
        {
            var irSwapDTO = _irSwapDAO.GetProductById(irSwapId);
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
            _irSwapBuilder.AddPrice(irSwapDTO.Price);
            return _irSwapBuilder.Build();

        }
    }
}