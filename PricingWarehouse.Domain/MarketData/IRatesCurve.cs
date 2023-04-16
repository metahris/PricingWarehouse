namespace PricingWarehouse.Domain
{
    public interface IRatesCurve
    {
        string CurveType { get;}
        string Currency { get;}
        DateTime CurveDate { get;}
        string InterpolationType { get;}
        string ExtrapolationType { get;}
        IList<CurveNode> Nodes { get;}
    }
}
