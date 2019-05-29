namespace Client.Features.Edge.EdgeCurrencyWallet
{
  using MediatR;

  public class SetSelectedCurrencyAction: IRequest<EdgeCurrencyWalletsState>
  {
    public string CurrencyCode { get; set; }
  }
}
