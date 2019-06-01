namespace Server.Services.CryptoCompare.SingleSymbolPrice
{
  using MediatR;
  public class SingleSymbolPriceRequest : IRequest<SingleSymbolPriceResponse>
    {
    public string tsyms { get; set; }

    public string fsym { get; set; }
  }
}
