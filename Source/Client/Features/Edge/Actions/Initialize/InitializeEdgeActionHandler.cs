namespace Client.Features.Edge
{
  using System;
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using Client.Features.Base;
  using Microsoft.JSInterop;

  public partial class EdgeState
  {

    public class InitializeEdgeActionHandler : BaseHandler<InitailizeEdgeAction, EdgeState>
    {
      public InitializeEdgeActionHandler(IStore aStore) : base(aStore) { }

      public override async Task<EdgeState> Handle(InitailizeEdgeAction aInitailizeEdgeRequest, CancellationToken aCancellationToken)
      {
        await JSRuntime.Current.InvokeAsync<bool>(EdgeInteropMethodNames.EdgeInterop_InitializeEdge);
        
        return EdgeState;
      }
    }
  }
}