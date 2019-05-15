namespace Server.Services.CryptoCompare.SingleSymbolPrice
{ 
  using FluentValidation;
  using static Server.Services.CryptoCompare.CryptoCompareConstants;

  public class SingleSymbolPriceRequestValidator : AbstractValidator<SingleSymbolPriceRequest>
  {
    public SingleSymbolPriceRequestValidator()
    {
      //RuleFor(aPriceRequest => aPriceRequest.Url.ToLower())
      //  .Equal($"{UsdCurrencyCode}{EthCurrencyCode}".ToLower());
    }
  }
}
