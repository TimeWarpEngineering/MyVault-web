namespace Client.Features.Edge
{
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using Client.Features.Base;
  using Microsoft.AspNetCore.Components;
  using Microsoft.JSInterop;


  //TODO: this doesn't use any state so maybe doesn't need BaseHandler
  public partial class EdgeState
  {
    public class ShowLoginWindowEdgeActionHandler : BaseHandler<ShowLoginWindowEdgeAction, EdgeState>
    {
      public ShowLoginWindowEdgeActionHandler(IStore aStore) : base(aStore) { }
      [Inject] IJSRuntime JSRuntime { get; }
      public override async Task<EdgeState> Handle(ShowLoginWindowEdgeAction aShowLoginWindowEdgeRequest, CancellationToken aCancellationToken)
      {
        await JSRuntime.InvokeAsync<bool>(EdgeInteropMethodNames.EdgeUiContextInterop_ShowLoginWindow);
        return EdgeState;
      }
    }
  }
}