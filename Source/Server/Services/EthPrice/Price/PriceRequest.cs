namespace Server.Services.EthPrice.Price
{
  using MediatR;
  using static Server.Services.EthPrice.EthPriceConstants;

  public class PriceRequest: IRequest<PriceResponse>
    {
    public string Url { get; set; } = $"{EthPriceUrl}{EthApi}";
    //public RangeEnum Range { get; set; } = RangeEnum.MINUTE_1;
  }
}
