using PricingWarehouse.Domain;
using PricingWarehouse.Domain.IRSwap;

namespace PricingWarehouse.Domaine.Swaptions
{
    public interface ISwaption
    {
        ProductType ProductType { get; }
        OptionType OptionType { get; }    
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

        public OptionValuationDate OptionValuationDate { get; private set; }

        public OptionExpirationDate OptionExpirationDarte { get; private set; }

        public SwapStartDate SwapStartDate { get; private set; }

        public SwapEndDate SwapEndDate { get; private set; }

        public OptionPrice OptionPrice { get; private set; }

        public StrikeRate StrikeRate { get; private set; }

        public SpotRate SpotRate { get; private set; }

        public NotionalAmount NotionalAmount { get; private set; }

        public PricingModel PricingModel { get; private set; }

        public PricedBy PricedBy { get; private set; }

        public int SwaptionId { get; private set; }

        public EuropeanSwaption(OptionType optionType, OptionValuationDate optionValuationDate, OptionExpirationDate optionExpirationDarte, SwapStartDate swapStartDate, SwapEndDate swapEndDate, OptionPrice optionPrice, StrikeRate strikeRate, SpotRate spotRate, NotionalAmount notionalAmount, PricingModel pricingModel, PricedBy pricedBy, int swaptionId)
        {
            if (OptionValuationDate is null)
            {
                throw new ArgumentNullException($"{nameof(OptionValuationDate)} can't be null");
            }
            if (optionExpirationDarte is null)
            {
                throw new ArgumentNullException($"{nameof(optionExpirationDarte)} can't be null");
            }
            if (SwapStartDate is null)
            {
                throw new ArgumentNullException($"{nameof(SwapStartDate)} can't be null");
            }
            if (swapEndDate is null)
            {
                throw new ArgumentNullException($"{nameof(swapEndDate)} can't be null");
            }
            if (strikeRate is null)
            {
                throw new ArgumentNullException($"{nameof(strikeRate)} can't be null");
            }
            if (spotRate is null)
            {
                throw new ArgumentNullException($"{nameof(spotRate)} can't be null");
            }
            if (pricedBy is null)
            {
                throw new ArgumentNullException($"{nameof(pricedBy)} can't be null");
            }
            OptionType = optionType;
            OptionValuationDate = optionValuationDate;
            OptionExpirationDarte = optionExpirationDarte;
            SwapStartDate = swapStartDate;
            SwapEndDate = swapEndDate;
            OptionPrice = optionPrice;
            StrikeRate = strikeRate;
            SpotRate = spotRate;
            NotionalAmount = notionalAmount;
            PricingModel = pricingModel;
            PricedBy = pricedBy;
            SwaptionId = swaptionId;
        }

        public void SetOptionType(OptionType optionType)
        {
            OptionType = optionType;
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
