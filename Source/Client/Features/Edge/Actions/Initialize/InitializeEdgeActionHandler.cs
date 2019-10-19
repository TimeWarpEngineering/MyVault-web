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

    public class InitializeEdgeActionHandler : BaseHandler<InitailizeEdgeAction>
    {
      public InitializeEdgeActionHandler(IStore aStore, IJSRuntime aJSRuntime):base(aStore)
      {
        JSRuntime = aJSRuntime;
      }

      private IJSRuntime JSRuntime { get; }

      public override async Task<Unit> Handle(InitailizeEdgeAction aInitailizeEdgeRequest, CancellationToken aCancellationToken)
      {
        await JSRuntime.InvokeAsync<bool>(EdgeInteropMethodNames.EdgeInterop_InitializeEdge);

        return Unit.Value;
      }
    }
  }
}