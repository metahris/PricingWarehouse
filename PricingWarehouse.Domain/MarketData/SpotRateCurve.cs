namespace PricingWarehouse.Domain
{
    public class SpotRateCurve:IRatesCurve
    {
        public string CurveType { get { return "SpotRateCurve"; } }
        public string Currency { get; private set; }
        public DateTime CurveDate { get; private set; }
        public string InterpolationType { get; private set; }
        public string ExtrapolationType { get; private set; }
        public IList<CurveNode> Nodes { get; private set; }
        public SpotRateCurve(string currency, DateTime curveDate, string interpolationType, string extrapolationType, IList<CurveNode> nodes)
        {
            Currency = currency;
            CurveDate = curveDate;
            InterpolationType = interpolationType;
            ExtrapolationType = extrapolationType;
            Nodes = nodes;
        }
    }
}
