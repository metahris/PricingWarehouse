namespace PricingWarehouse.Domain
{
    public  interface IOption:IProduct
    {
        PricingModel PricingModel { get; }
        ValuationDate OptionValuationDate { get; }
        StartDate OptionEffectiveDate { get; }
        EndDate OptionExpirationDate { get; }
        Delta Delta { get; }
        Gamma Gamma { get; }
        Vega Vega { get; }
        void SetUnderlyingPrice(double price);
        double GetUnderlyingPrice();
        void SetDelta(double delta);
        void SetGamma(double gamma);
        void SetVega(double vega);
    }
}
