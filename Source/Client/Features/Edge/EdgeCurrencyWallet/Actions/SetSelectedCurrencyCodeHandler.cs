namespace Client.Features.Edge.EdgeCurrencyWallet
{
  using BlazorState;
  using Client.Features.Base;
  using System.Threading;
  using System.Threading.Tasks;

  public partial class EdgeCurrencyWalletsState
  {
    public class SetSelectedCurrencyCodeHandler : BaseHandler<SetSelectedCurrencyAction, EdgeCurrencyWalletsState>
    {
      public SetSelectedCurrencyCodeHandler(IStore aStore) : base(aStore) { }

      public override Task<EdgeCurrencyWalletsState> Handle(SetSelectedCurrencyAction aSetSelectedCurrencyAction, CancellationToken aCancellationToken)
      {
        EdgeCurrencyWalletsState.SelectedEdgeCurrencyWallet.SelectedCurrencyCode = aSetSelectedCurrencyAction.CurrencyCode;

        return Task.FromResult(EdgeCurrencyWalletsState);
      }
    }
  }
}
