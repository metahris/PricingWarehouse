namespace PricingWarehouse.DTO
{
    public class IRSwapDTO : IProductDTO
    {
        public string Currency { get; set; }  // Swap currency 
        public double Notional { get; set; }
        public double FixedRate { get; set; }  // Fixed rate 
        public string FloatingRateReference { get; set; }  // Reference rate (e.g. "EURIBOR")
        public double FloatingRateSpread { get; set; }  // Swap Spread 
        public string DayCountConvention { get; set; }
        public int PaymentFrequencyMonths { get; set; }  // Payment frequency in months 
        public DateTime ValuationDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double SwapValue { get; set; }

    }
}
