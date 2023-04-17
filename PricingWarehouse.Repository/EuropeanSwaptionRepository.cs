using PricingWarehouse.DAO;
using PricingWarehouse.Domain;
using PricingWarehouse.DTO;

namespace PricingWarehouse.Repository
{
    public class EuropeanSwaptionRepository:IProductRepository<EuropeanSwaption>
    {
        private readonly EuropeanSwaptionDAO _europeanSwaptionDAO;
        private readonly EuropeanSwaptionBuilder _europeanSwaptionBuilder;
        private readonly IRSwapBuilder _irSwapBuilder;
        public EuropeanSwaptionRepository(EuropeanSwaptionDAO europeanSwaptionDAO, EuropeanSwaptionBuilder europeanSwaptionBuilder, IRSwapBuilder irSwapBuilder)
        {
            _europeanSwaptionBuilder = europeanSwaptionBuilder;
            _europeanSwaptionDAO = europeanSwaptionDAO;
            _irSwapBuilder = irSwapBuilder;
        }
        public int InsertProduct(EuropeanSwaption europeanSwaption)
        {
            var europeanSwaptionDTO = new EuropeanSwaptionDTO
            {
                OptionType = europeanSwaption.OptionType.ToString(),
                SettlementType = europeanSwaption.SettlementType.ToString(),
                OptionEffectiveDate = europeanSwaption.OptionEffectiveDate.Value,
                OptionExpirationDate = europeanSwaption.OptionExpirationDate.Value,
                OptionValuationDate = europeanSwaption.OptionValuationDate.Value,
                SwapStartDate = europeanSwaption.UnderlyingSwap.StartDate.Value,
                SwapEndDate = europeanSwaption.UnderlyingSwap.EndDate.Value,
                Price = europeanSwaption.Price.Value,
                StrikeRate = europeanSwaption.UnderlyingSwap.FixedRate.Value,
                FloatingRateReference = europeanSwaption.UnderlyingSwap.FloatingRateReference.Value,
                Currency = europeanSwaption.UnderlyingSwap.Currency.Value,
                NotionalAmount = europeanSwaption.UnderlyingSwap.Notional.Value,
                PricingModel = europeanSwaption.PricingModel.ToString(), 
                PaymentFrequencyMonths = europeanSwaption.UnderlyingSwap.PaymentFrequencyMonths.Value,
                DayCountConvention = europeanSwaption.UnderlyingSwap.DayCountConvention.Value
            };
            return _europeanSwaptionDAO.InsertProduct(europeanSwaptionDTO);
        }

        public EuropeanSwaption GetProductById(int europeanSwaptionId)
        {
            var europeanSwaptionDTO = _europeanSwaptionDAO.GetProductById(europeanSwaptionId);
            _europeanSwaptionBuilder.AddOptionType((OptionType)Enum.Parse(typeof(OptionType), europeanSwaptionDTO.OptionType, true));
            _europeanSwaptionBuilder.AddSettlementType((SettlementType)Enum.Parse(typeof(SettlementType), europeanSwaptionDTO.SettlementType, true));
            _europeanSwaptionBuilder.AddOptionEffectiveDate(europeanSwaptionDTO.OptionEffectiveDate);
            _europeanSwaptionBuilder.AddOptionExpirationDate(europeanSwaptionDTO.OptionExpirationDate);
            _europeanSwaptionBuilder.AddValuationDate(europeanSwaptionDTO.OptionValuationDate);
            _europeanSwaptionBuilder.AddPricingModel((PricingModel)Enum.Parse(typeof(PricingModel), europeanSwaptionDTO.PricingModel, true));
            _europeanSwaptionBuilder.AddUnderlyingSwap(
                europeanSwaptionDTO.StrikeRate,
                europeanSwaptionDTO.FloatingRateReference,
                europeanSwaptionDTO.FloatingRateSpread,
                europeanSwaptionDTO.PaymentFrequencyMonths,
                europeanSwaptionDTO.Price,
                europeanSwaptionDTO.Currency,
                europeanSwaptionDTO.DayCountConvention,
                europeanSwaptionDTO.OptionEffectiveDate,
                europeanSwaptionDTO.OptionExpirationDate,
                europeanSwaptionDTO.NotionalAmount,
                europeanSwaptionDTO.OptionValuationDate,
                _irSwapBuilder
            );
            _europeanSwaptionBuilder.AddPrice(europeanSwaptionDTO.Price);
            _europeanSwaptionBuilder.AddPricingModel((PricingModel)Enum.Parse(typeof(PricingModel), europeanSwaptionDTO.PricingModel, true));

            return _europeanSwaptionBuilder.Build();
        }
    }
}
