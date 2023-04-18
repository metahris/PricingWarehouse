using DryIoc;

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

        public Delta Delta { get; private set; }
        public Gamma Gamma { get; private set; }
        public Vega Vega { get; private set; }

        public EuropeanSwaption(OptionType optionType, SettlementType settlementType, ValuationDate optionValuationDate,
            StartDate optionEffectiveDate, EndDate optionExpirationDate, Price price, PricingModel pricingModel,
            IRSwap underlyingSwap, Delta delta, Gamma gamma, Vega vega)
        {
            OptionType = optionType;
            SettlementType = settlementType;
            OptionValuationDate = optionValuationDate;
            OptionEffectiveDate = optionEffectiveDate;
            OptionExpirationDate = optionExpirationDate;
            Price = price;
            PricingModel = pricingModel;
            UnderlyingSwap = underlyingSwap;
            Delta = delta;   
            Gamma = gamma;
            Vega = vega;
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
        public void SetUnderlyingPrice(double price)
        {
            UnderlyingSwap.SetPrice(price);
        }
        public double GetUnderlyingPrice()
        {
            return UnderlyingSwap.Price.Value;
        }
        public override string ToString()
        {
            return $"{ProductType}";
        }
        public void SetDelta(double delta)
        {
            if (Delta == null)
            {
                Delta = new Delta(delta);
            }
            else
            {
                Delta.Value = delta;
            }
        }

        public void SetGamma(double gamma)
        {
            if (Gamma == null)
            {
                Gamma = new Gamma(gamma);
            }
            else
            {
                Gamma.Value = gamma;
            }
        }
        public void SetVega(double vega)
        {
            if (Vega == null)
            {
                Vega = new Vega(vega);
            }
            else
            {
                Vega.Value = vega;
            }
        }
    }
}
