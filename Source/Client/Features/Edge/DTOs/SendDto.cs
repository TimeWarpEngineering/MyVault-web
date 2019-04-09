namespace Client.Features.Edge.Dtos
{
  public class SendDto
  {
    public string EdgeCurrencyWalletId { get; set; }
    public string DestinationAddress { get; set; }

    public string NativeAmount { get; set; }

    public string CurrencyCode { get; set; }

    public string Fee { get; set; }
  }
}
