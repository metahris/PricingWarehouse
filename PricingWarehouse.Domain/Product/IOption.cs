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
    }
}
