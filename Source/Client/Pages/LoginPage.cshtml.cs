namespace Client.Pages
{
  using System.Threading.Tasks;
  using Client.Components;

  public class LoginPageModel : BaseComponent
  {
    public const string Route = "Login";


    protected override async Task OnInitAsync()
    {

      // Are we in the proper state for this page?
      if (EdgeAccountState.LoggedIn)
      {
          // Route them to Home Page
          await Mediator.Send(new BlazorState.Features.Routing.ChangeRouteRequest { NewRoute = HomeModel.Route });
      }
      else
      {
        await Mediator.Send(new BlazorState.Features.Routing.ChangeRouteRequest { NewRoute = EdgePageModel.Route });
      }
    }

    //protected override void OnInit()
    //{
    //  // Are we in the proper state for this page?
    //  if (EdgeState.IsLoggedIn) 
    //  {
    //    if (IdologyState.IsValid)
    //    {
    //      // Route them to Home Page
    //      Mediator.Send(new BlazorState.Features.Routing.ChangeRouteRequest { NewRoute = HomeModel.Route});
    //    } else
    //    {
    //      // Route them to Idology Page
    //      Mediator.Send(new BlazorState.Features.Routing.ChangeRouteRequest { NewRoute = IdologyModel.Route});
    //    }
    //  } else
    //  {
    //    Mediator.Send(new BlazorState.Features.Routing.ChangeRouteRequest { NewRoute = EdgeModel.Route });
    //  }


    //  base.OnInit();
    //}
  }
}
