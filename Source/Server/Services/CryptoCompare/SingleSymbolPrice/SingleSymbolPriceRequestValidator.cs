namespace Server.Services.CryptoCompare.SingleSymbolPrice
{
  using FluentValidation;
  using static Shared.Constants.CurrencyCodes;
  public class SingleSymbolPriceRequestValidator : AbstractValidator<SingleSymbolPriceRequest>
  {
    public SingleSymbolPriceRequestValidator()
    {
      RuleFor(aSingleSymbolPriceRequest => aSingleSymbolPriceRequest.tsyms.ToLower())
        .Equal($"{UsdCurrencyCode}".ToLower());
      RuleFor(aSingleSymbolPriceRequest => aSingleSymbolPriceRequest.fsym.ToLower())
        .Equal($"{EthCurrencyCode}".ToLower());
    }
  }
}
