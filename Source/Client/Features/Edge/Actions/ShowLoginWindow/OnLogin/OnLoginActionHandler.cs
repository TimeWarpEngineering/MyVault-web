namespace Client.Features.Edge
{
  using System;
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using Client.Features.Base;
  using Client.Pages;
  using MediatR;

  public partial class EdgeState
  {
    public class OnLoginActionHandler : BaseHandler<OnLoginAction, EdgeState>
    {
      public OnLoginActionHandler(IStore aStore, IMediator aMediator) : base(aStore)
      {
        Mediator = aMediator;
      }

      private IMediator Mediator { get; }

      public override async Task<EdgeState> Handle(OnLoginAction aOnLoginRequest, CancellationToken aCancellationToken)
      {
        Console.WriteLine($"OnLoginActionHandler");
        await Mediator.Send(new BlazorState.Features.Routing.ChangeRouteRequest { NewRoute = WalletPageModel.Route });
        return EdgeState;
      }
    }
  }
}