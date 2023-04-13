using PricingWarehouse.Domain.Product;

namespace PricingWarehouse.Domain.Swaption
{
    public interface ISwaption: IProduct
    {
        ProductType ProductType { get; }
        OptionType OptionType { get; }    
        SettlementType SettlementType { get; }
        ValuationDate OptionValuationDate { get; }
        StartDate OptionEffectiveDate { get; }
        EndDate OptionExpirationDate { get; }
        OptionPrice OptionPrice { get; }
        PricingModel PricingModel { get; }    
        int SwaptionId { get; } 
        IRSwap UnderlyingSwap { get; }
        void SetSwaptionPrice(double price);
        void SetSwaptionId(int swaptionId);
        void SetOptionType(OptionType optionType);
    }
    public class EuropeanSwaption : ISwaption
    {
        public ProductType ProductType { get { return ProductType.EuropeanSwaption; } }
        public OptionType OptionType { get; private set; }
        public SettlementType SettlementType { get; private set; }
        public ValuationDate OptionValuationDate { get; private set; }
        public StartDate OptionEffectiveDate { get; private set; }
        public EndDate OptionExpirationDate { get; private set; }
        public OptionPrice OptionPrice { get; private set; }
        public PricingModel PricingModel { get; private set; }
        public int SwaptionId { get; private set; }
        public IRSwap UnderlyingSwap { get; private set; }

        public EuropeanSwaption(OptionType optionType, SettlementType settlementType, ValuationDate optionValuationDate,
            StartDate optionEffectiveDate, EndDate optionExpirationDate, OptionPrice optionPrice, PricingModel pricingModel,
            IRSwap underlyingSwap)
        {
            OptionType = optionType;
            SettlementType = settlementType;
            OptionValuationDate = optionValuationDate;
            OptionEffectiveDate = optionEffectiveDate;
            OptionExpirationDate = optionExpirationDate;
            OptionPrice = optionPrice;
            PricingModel = pricingModel;
            UnderlyingSwap = underlyingSwap;
        }

        public void SetOptionType(OptionType optionType)
        {
            OptionType = optionType;
        }
        public void SetSettlementType(SettlementType settlementType)
        {
            SettlementType = settlementType;
        }

        public void SetSwaptionId(int swaptionId)
        {
            SwaptionId = swaptionId;
        }

        public void SetSwaptionPrice(double price)
        {
            if (OptionPrice == null)
            {
                OptionPrice = new OptionPrice(price);
            }
            else
            {
                OptionPrice.Value = price;
            }
        }
        public override string ToString()
        {
            return $"{ProductType}";
        }
    }
}
