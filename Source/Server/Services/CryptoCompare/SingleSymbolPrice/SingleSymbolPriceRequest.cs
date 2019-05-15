namespace Server.Services.CryptoCompare.SingleSymbolPrice
{
  using MediatR;
  using static Server.Services.CryptoCompare.CryptoCompareConstants;
  public class SingleSymbolPriceRequest : IRequest<SingleSymbolPriceResponse>
    {
    public string tsyms { get; set; }

    public string fsym { get; set; }
  }
}
