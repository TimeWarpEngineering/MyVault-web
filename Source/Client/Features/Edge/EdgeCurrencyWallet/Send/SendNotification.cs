namespace Client.Features.Edge
{
  using MediatR;
  using static Client.Features.Edge.EdgeCurrencyWalletsState;

  internal class SendNotification : INotification
  {
    public SendAction SendAction { get; set; }
    public string TransactionId { get; set; }
  }
}
