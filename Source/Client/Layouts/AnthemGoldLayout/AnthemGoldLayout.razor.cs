namespace Client.Layouts.AnthemGoldLayout
{
  using System.Threading.Tasks;
  using Client.Components;
  using Client.Pages;
  using Microsoft.AspNetCore.Components;
  using static BlazorState.Features.Routing.RouteState;

  public class AnthemGoldLayoutBase : BaseComponent, IComponent
  {

    [Parameter] public RenderFragment Body { get; set; }

    protected override async Task OnAfterRenderAsync(bool aFirstRender)
    {
      // Are we in the proper state for this page?
      if (!EdgeAccountState.LoggedIn)
      {
        // Route to Edge to Login
        _ = await Mediator.Send(new ChangeRouteAction { NewRoute = EdgePageBase.Route });
      }
    }
  }
}
