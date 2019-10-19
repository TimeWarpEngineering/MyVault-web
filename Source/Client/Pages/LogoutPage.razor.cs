namespace Client.Pages
{
  using Client.Components;
  using System.Threading.Tasks;
  using static BlazorState.Features.Routing.RouteState;
  using static Client.Features.Edge.EdgeAccount.EdgeAccountState;

  public class LogoutPageBase : BaseComponent
  {
    public const string Route = "logout";

    protected override async Task OnAfterRenderAsync(bool aFirstRender)
    {
      await Mediator.Send(new LogoutAction());
      await Mediator.Send(new ChangeRouteAction { NewRoute = HomeBase.Route });
    }
  }
}