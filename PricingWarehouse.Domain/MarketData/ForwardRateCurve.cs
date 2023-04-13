namespace PricingWarehouse.Domain.MarketData
{
    public class ForwardRateCurve:IRatesCurve
    {
        public string CurveType { get { return "ForwardRateCurve"; } }
        public string Currency { get; private set; }
        public DateTime CurveDate { get; private set; }
        public string InterpolationType { get; private set; }
        public string ExtrapolationType { get; private set; }
        public List<CurveNode> Nodes { get; private set; }
    }
}
