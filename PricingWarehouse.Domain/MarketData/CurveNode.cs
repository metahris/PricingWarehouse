namespace PricingWarehouse.Domain.MarketData
{
    public class CurveNode
    {
        public string Tenor { get; private set; }
        public double Value { get; private set; }
        public CurveNode(string tenor, double value)
        {
            Tenor = tenor;
            Value = value;
        }
    }
}
