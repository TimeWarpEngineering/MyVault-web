namespace Client.Features.Edge
{
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using Client.Features.Base;
  using MediatR;
  using Microsoft.AspNetCore.Components;
  using Microsoft.JSInterop;



  public partial class EdgeState
  {
    public class ShowLoginWindowEdgeActionHandler : BaseHandler<ShowLoginWindowEdgeAction>
    {
      public ShowLoginWindowEdgeActionHandler(IStore aStore, IJSRuntime aJSRuntime) : base(aStore)
      {
        JSRuntime = aJSRuntime;
      }

      public ShowLoginWindowEdgeActionHandler( IStore aStore) : base(aStore) { }
      private IJSRuntime JSRuntime { get; }
      public override async Task<Unit> Handle(ShowLoginWindowEdgeAction aShowLoginWindowEdgeRequest, CancellationToken aCancellationToken)
      {
        await JSRuntime.InvokeAsync<bool>(EdgeInteropMethodNames.EdgeUiContextInterop_ShowLoginWindow);
        return Unit.Value;
      }
    }
  }
}