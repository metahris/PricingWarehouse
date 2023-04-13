namespace PricingWarehouse.Domain.MarketData
{
    public interface IRatesCurve
    {
        string CurveType { get;}
        string Currency { get;}
        DateTime CurveDate { get;}
        string InterpolationType { get;}
        string ExtrapolationType { get;}
        List<CurveNode> Nodes { get;}
    }
}
