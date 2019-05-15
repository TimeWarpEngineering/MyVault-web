namespace Server.Services.AnthemGold.Price
{
  using MediatR;
  using static Server.Services.AnthemGold.AnthemGoldConstants;

  public class PriceRequest: IRequest<PriceResponse>
    {
    public string Symbol { get; set; } = $"{UsdCurrencyCode}{AgldCurrencyCode}";
    public RangeEnum Range { get; set; } = RangeEnum.MINUTE_1;
  }
}
