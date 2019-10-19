namespace Client.Pages
{
  using Client.Components;
  using System.Threading.Tasks;
  using static BlazorState.Features.Routing.RouteState;
  
  public class LoginPageBase : BaseComponent
  {
    public const string Route = "Login";


    protected override async Task OnAfterRenderAsync(bool aFirstRender)
    {

      // Are we in the proper state for this page?
      if (EdgeAccountState.LoggedIn)
      {
          // Route them to Home Page
        await Mediator.Send(new ChangeRouteAction { NewRoute = HomeBase.Route });
      }
      else
      {
        await Mediator.Send(new ChangeRouteAction { NewRoute = EdgePageBase.Route });
      }
    }
  }
}
