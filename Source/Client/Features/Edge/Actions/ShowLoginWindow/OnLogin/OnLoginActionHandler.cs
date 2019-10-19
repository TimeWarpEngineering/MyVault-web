namespace Client.Features.Edge
{
  using BlazorState;
  using Client.Features.Base;
  using Client.Pages;
  using MediatR;
  using System;
  using System.Threading;
  using System.Threading.Tasks;
  using static BlazorState.Features.Routing.RouteState;

  public partial class EdgeState
  {
    public class OnLoginActionHandler : BaseHandler<OnLoginAction>
    {
      public OnLoginActionHandler(IStore aStore, IMediator aMediator) : base(aStore)
      {
        Mediator = aMediator;
      }

      private IMediator Mediator { get; }

      public override async Task<Unit> Handle(OnLoginAction aOnLoginRequest, CancellationToken aCancellationToken)
      {
        Console.WriteLine($"OnLoginActionHandler");

        await Mediator.Send(new ChangeRouteAction { NewRoute = WalletPage.Route });
        return Unit.Value;
      }
    }
  }
}