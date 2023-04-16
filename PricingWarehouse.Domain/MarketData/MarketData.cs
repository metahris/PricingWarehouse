namespace PricingWarehouse.Domain
{
    public interface IMarketData
    {
        DateTime MarketDate { get;}
        DiscountCurve DiscountCurve { get;}
        ForwardRateCurve ForwardRatesCurve { get;}
        SpotRateCurve SpotRateCurve { get;}
        IList<IVolatilityPoint> Volatilities { get;}
    }
    public class MarketData : IMarketData
    {
        public DateTime MarketDate { get; private set; }
        public DiscountCurve DiscountCurve { get; private set; }
        public ForwardRateCurve ForwardRatesCurve { get; private set; }
        public SpotRateCurve SpotRateCurve { get; private set; }
        public IList<IVolatilityPoint> Volatilities { get; private set; }
        public MarketData(DateTime marketDate, DiscountCurve discountCurve, ForwardRateCurve forwardRatesCurve, SpotRateCurve spotRateCurve, IList<IVolatilityPoint> volatilities)
        {
            MarketDate = marketDate;
            DiscountCurve = discountCurve;
            ForwardRatesCurve = forwardRatesCurve;
            SpotRateCurve = spotRateCurve;
            Volatilities = volatilities;
        }
    }
}
