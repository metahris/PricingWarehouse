using OptionPricer.Infrastructure;

namespace PricingWarehouse.Domain.MarketData
{
    public interface IMarketData
    {
        string Serialize(IObjectSerializer objectSerializer);
        MarketData Deserialize(string json, IObjectSerializer objectSerializer);
    }
    public class MarketData
    {
        public DateTime MarketDate { get; private set; }
        public DiscountCurve DiscountCurve { get; private set; }
        public ForwardRateCurve ForwardRatesCurve { get; private set; }
        public SpotRateCurve SpotRateCurve { get; private set; }
        public List<IVolatilityPoint> Volatilities { get; private set; }
        public MarketData(DateTime marketDate, ForwardRateCurve forwardRatesCurve, DiscountCurve discountCurve, SpotRateCurve spotRateCurve, List<IVolatilityPoint> volatilities)
        {
            MarketDate = marketDate;
            ForwardRatesCurve = forwardRatesCurve;
            DiscountCurve = discountCurve;
            SpotRateCurve = spotRateCurve;
            Volatilities = volatilities;
        }
        public string Serialize(IObjectSerializer objectSerializer)
        {
            return objectSerializer.Serialize(this);
        }

        public static MarketData Deserialize(string json, IObjectSerializer objectSerializer)
        {
            return objectSerializer.Deserialize<MarketData>(json);
        }
    }
}
