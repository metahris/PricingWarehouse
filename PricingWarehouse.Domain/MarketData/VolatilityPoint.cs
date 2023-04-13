namespace PricingWarehouse.Domain.MarketData
{
    public interface IVolatilityPoint
    {
        string Maturity { get; }
        double Strike { get; }
        double Value { get; }
    }
    public class VolatilityCubePoint: IVolatilityPoint
    {
        public string Maturity { get; private set; }
        public string Tenor { get; private set; }
        public double Strike { get; private set; }
        public double Value { get; private set; }
        public VolatilityCubePoint(string maturity, string tenor, double strike, double value)
        {
            Maturity = maturity;
            Tenor = tenor;
            Strike = strike;
            Value = value;

        }
    }
    public class VolatilitySurfacePoint:IVolatilityPoint
    {
        public string Maturity { get; private set; }
        public double Strike { get; private set; }
        public double Value { get; private set; }
        public VolatilitySurfacePoint(string maturity, double strike, double value)
        {
            Maturity = maturity;
            Strike = strike;
            Value = value;
        }
    }
}
