namespace Client.Features.Edge
{
  using BlazorState;
  using Client.Features.Base;
  using MediatR;
  using System.Threading;
  using System.Threading.Tasks;

  public partial class EdgeCurrencyWalletsState
  {
    public class SetSelectedCurrencyCodeHandler : BaseHandler<SetSelectedCurrencyAction>
    {
      public SetSelectedCurrencyCodeHandler(IStore aStore) : base(aStore) { }

      public override Task<Unit> Handle(SetSelectedCurrencyAction aSetSelectedCurrencyAction, CancellationToken aCancellationToken)
      {
        EdgeCurrencyWalletsState.SelectedEdgeCurrencyWallet.SelectedCurrencyCode = aSetSelectedCurrencyAction.CurrencyCode;

        return Unit.Task;
      }
    }
  }
}
