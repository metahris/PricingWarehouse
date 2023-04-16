namespace PricingWarehouse.Domain
{
    public interface ISwaption: IOption
    {
        ProductType ProductType { get; }
        OptionType OptionType { get; }    
        SettlementType SettlementType { get; } 
        IRSwap UnderlyingSwap { get; }
        void SetSwaptionType(OptionType optionType);
    }
    public class EuropeanSwaption : ISwaption
    {
        public int Id { get;private set; }
        public ProductType ProductType { get { return ProductType.EuropeanSwaption; } }
        public OptionType OptionType { get; private set; }
        public SettlementType SettlementType { get; private set; }
        public ValuationDate OptionValuationDate { get; private set; }
        public StartDate OptionEffectiveDate { get; private set; }
        public EndDate OptionExpirationDate { get; private set; }
        public Price Price { get; private set; }
        public PricingModel PricingModel { get; private set; }
        public IRSwap UnderlyingSwap { get; private set; }

        public EuropeanSwaption(OptionType optionType, SettlementType settlementType, ValuationDate optionValuationDate,
            StartDate optionEffectiveDate, EndDate optionExpirationDate, Price price, PricingModel pricingModel,
            IRSwap underlyingSwap)
        {
            OptionType = optionType;
            SettlementType = settlementType;
            OptionValuationDate = optionValuationDate;
            OptionEffectiveDate = optionEffectiveDate;
            OptionExpirationDate = optionExpirationDate;
            Price = price;
            PricingModel = pricingModel;
            UnderlyingSwap = underlyingSwap;
        }

        public void SetSwaptionType(OptionType optionType)
        {
            OptionType = optionType;
        }
        public void SetSettlementType(SettlementType settlementType)
        {
            SettlementType = settlementType;
        }

        public void SetId(int id)
        {
            Id = id;
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
        public override string ToString()
        {
            return $"{ProductType}";
        }
    }
}
