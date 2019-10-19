namespace Client.Features.Edge.EdgeAccount
{
  using BlazorState;
  using Client.Features.Base;
  using MediatR;
  using System.Threading;
  using System.Threading.Tasks;

  public partial class EdgeAccountState
  {
    public class UpdateEdgeAccountHandler : BaseHandler<UpdateEdgeAccountAction>
    {
      public UpdateEdgeAccountHandler(IStore aStore) : base(aStore) { }

    private void MapActionToState(UpdateEdgeAccountAction aUpdateEdgeAccountAction)
    {
      EdgeAccountState.Id = aUpdateEdgeAccountAction.Id;
      EdgeAccountState.LoggedIn = aUpdateEdgeAccountAction.LoggedIn;
      EdgeAccountState.Username = aUpdateEdgeAccountAction.Username;
    }

      public override Task<Unit> Handle(UpdateEdgeAccountAction aUpdateEdgeAccountAction, CancellationToken aCancellationToken)
    {
      MapActionToState(aUpdateEdgeAccountAction);
        return Unit.Task;
      }
    }
  }
}