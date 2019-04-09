namespace Client.Features.Edge.EdgeCurrencyWallet
{
  using MediatR;

  internal class SendNotification : INotification
  {
    public SendAction SendAction { get; set; }
    public string TransactionId { get; set; }
  }
}
