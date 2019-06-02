namespace Client.Features.Edge.EdgeAccount
{
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using Client.Features.Base;

  public class UpdateEdgeAccountHandler : BaseHandler<UpdateEdgeAccountAction, EdgeAccountState>
  {
    public UpdateEdgeAccountHandler(IStore aStore) : base(aStore)
    {
    }

    public override async Task<EdgeAccountState> Handle(UpdateEdgeAccountAction aUpdateEdgeAccountAction, CancellationToken aCancellationToken)
    {
      MapActionToState(aUpdateEdgeAccountAction);
      return await Task.FromResult(EdgeAccountState);
    }

    private void MapActionToState(UpdateEdgeAccountAction aUpdateEdgeAccountAction)
    {
      EdgeAccountState.Id = aUpdateEdgeAccountAction.Id;
      EdgeAccountState.LoggedIn = aUpdateEdgeAccountAction.LoggedIn;
      EdgeAccountState.Username = aUpdateEdgeAccountAction.Username;
    }
  }
}
