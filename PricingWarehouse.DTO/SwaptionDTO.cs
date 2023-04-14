namespace PricingWarehouse.DTO
{
    public interface ISwaptionDTO : IProductDTO
    {
        string ProductType { get; }
        string OptionType { get; set; }
        string SettlementType { get; set; }
        DateTime OptionEffectiveDate { get; set; }
        DateTime OptionExpirationDate { get; set; }
        DateTime OptionValuationDate { get; set; }
        DateTime SwapStartDate { get; set; }
        DateTime SwapEndDate { get; set; }
        double OptionPrice { get; set; }
        double StrikeRate { get; set; }
        string FloatRateReference { get; set; }
        string Currency { get; set; }
        double NotionalAmount { get; set; }
        string PricingModel { get; set; }
        int PaymentFrequencyMonths { get; set; }
        string DayCountConvention { get; set; }
    }

    public class EuropeanSwaptionDTO : ISwaptionDTO
    {
        public string ProductType { get { return "European Swaption"; } }
        public string OptionType { get; set; }
        public string SettlementType { get; set; }
        public DateTime OptionEffectiveDate { get; set; }
        public DateTime OptionExpirationDate { get; set; }
        public DateTime OptionValuationDate { get; set; }
        public DateTime SwapStartDate { get; set; }
        public DateTime SwapEndDate { get; set; }
        public double OptionPrice { get; set; }
        public double StrikeRate { get; set; }
        public string FloatRateReference { get; set; }
        public string Currency { get; set; }
        public double NotionalAmount { get; set; }
        public string PricingModel { get; set; }
        public int PaymentFrequencyMonths { get; set; }
        public string DayCountConvention { get; set; }
    }

    public class BermudeanSwaptionDTO : ISwaptionDTO
    {
        public string ProductType { get { return "Bermudean Swaption"; } }
        public string OptionType { get; set; }
        public string SettlementType { get; set; }
        public DateTime OptionEffectiveDate { get; set; }
        public DateTime OptionExpirationDate { get; set; }
        public DateTime OptionValuationDate { get; set; }
        public DateTime SwapStartDate { get; set; }
        public DateTime SwapEndDate { get; set; }
        public double OptionPrice { get; set; }
        public double StrikeRate { get; set; }
        public string FloatRateReference { get; set; }
        public string Currency { get; set; }
        public double NotionalAmount { get; set; }
        public string PricingModel { get; set; }
        public int PaymentFrequencyMonths { get; set; }
        public string DayCountConvention { get; set; }
    }
}
