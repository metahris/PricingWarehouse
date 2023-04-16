namespace PricingWarehouse.Domain
{
    public class DiscountCurve:IRatesCurve
    {
        public string CurveType { get { return "DiscountCurve"; } }
        public string Currency { get; private set; }
        public DateTime CurveDate { get; private set; }
        public string InterpolationType { get; private set; }
        public string ExtrapolationType { get; private set; }
        public IList<CurveNode> Nodes { get; private set; }
        public DiscountCurve(string currency, DateTime curveDate, string interpolationType, string extrapolationType,IList<CurveNode> nodes)
        {
            Currency = currency;
            CurveDate = curveDate;
            InterpolationType = interpolationType;
            ExtrapolationType = extrapolationType;
            Nodes = nodes;
        }
    }
}
