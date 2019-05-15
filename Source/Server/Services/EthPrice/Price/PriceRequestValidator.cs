namespace Server.Services.EthPrice.Price
{
  using FluentValidation;
  using static Server.Services.AnthemGold.EthPriceConstants;

  public class PriceRequestValidator : AbstractValidator<PriceRequest>
  {
    public PriceRequestValidator()
    {
      RuleFor(aPriceRequest => aPriceRequest.Url.ToLower())
        .Equal($"{UsdCurrencyCode}{AgldCurrencyCode}".ToLower());
    }
  }
}
