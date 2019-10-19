namespace Client.Features.Edge.EdgeAccount
{
  using BlazorState;
  using Client.Features.Base;
  using MediatR;
  using Microsoft.JSInterop;
  using System.Threading;
  using System.Threading.Tasks;

  public partial class EdgeAccountState
  {
    public class LogoutHandler : BaseHandler<LogoutAction>
    {
      public LogoutHandler(IStore aStore, IJSRuntime aJSRuntime) : base(aStore)
      {
        JSRuntime = aJSRuntime;
      }

      private IJSRuntime JSRuntime { get; }

      public override async Task<Unit> Handle(LogoutAction aShowLoginWindowEdgeRequest, CancellationToken aCancellationToken)
      {
        await JSRuntime.InvokeAsync<bool>(EdgeInteropMethodNames.EdgeAccountInterop_Logout);
        EdgeAccountState.Initialize();
        Store.Reset(); // Clear the entire State.
        return Unit.Value;
      }
    }
  }
}