namespace Server.Services.AnthemGold.Price
{
  using MediatR;

  using static Shared.Constants.AnthemGoldConstants;
  using static Shared.Constants.CurrencyCodes;

  public class PriceRequest: IRequest<PriceResponse>
    {
    public string Symbol { get; set; } = $"{UsdCurrencyCode}{AgldCurrencyCode}";
    public RangeEnum Range { get; set; } = RangeEnum.MINUTE_1;
  }
}
