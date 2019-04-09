//namespace Herc.Pwa.Client.Features.Edge
//{
//  using System;
//  using System.Threading;
//  using System.Threading.Tasks;
//  using BlazorState;
//  using Herc.Pwa.Client.Features.Base;
//  using MediatR;
//  using Microsoft.JSInterop;

//  public partial class EdgeState
//  {
//    public class GetFirstWalletInfoHandler : BaseHandler<GetFirstWalletInfoAction, EdgeState>
//    {
//      public GetFirstWalletInfoHandler(IStore aStore, IMediator aMediator) : base(aStore)
//      {
//        Mediator = aMediator;
//      }

//      private IMediator Mediator { get; }

//      public override async Task<EdgeState> Handle(GetFirstWalletInfoAction aGetWalletAction, CancellationToken aCancellationToken)
//      {
//        string result = await JSRuntime.Current.InvokeAsync<string>(EdgeInteropMethodNames.EdgeAccountInterop_GetFirstWalletInfo, aGetWalletAction.Type);
//        EdgeState.EdgeWalletInfo = Json.Deserialize<EdgeWalletInfo>(result);

//        return EdgeState;
//      }
//    }
//  }
//}