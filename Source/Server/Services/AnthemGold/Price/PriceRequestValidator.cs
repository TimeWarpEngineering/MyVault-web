namespace Server.Services.AnthemGold.Price
{
  using FluentValidation;
  using static Server.Services.AnthemGold.AnthemGoldConstants;

  public class PriceRequestValidator : AbstractValidator<PriceRequest>
  {
    public PriceRequestValidator()
    {
      RuleFor(aPriceRequest => aPriceRequest.Symbol.ToLower())
        .Equal($"{UsdCurrencyCode}{AgldCurrencyCode}".ToLower());
    }
  }
}
