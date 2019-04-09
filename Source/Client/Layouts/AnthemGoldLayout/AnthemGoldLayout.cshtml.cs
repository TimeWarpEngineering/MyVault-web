namespace Client.Layouts.AnthemGoldLayout
{
  using System.Threading.Tasks;
  using Client.Components;
  using Client.Pages;
  using Microsoft.AspNetCore.Components;

  public class AnthemGoldLayoutModel : BaseComponent, IComponent
  {

    [Parameter] protected RenderFragment Body { get; set; }

    protected override async Task OnInitAsync()
    {
      // Are we in the proper state for this page?
      if (!EdgeAccountState.LoggedIn)
      {
        // Route to Edge to Login
        await Mediator.Send(new BlazorState.Features.Routing.ChangeRouteRequest { NewRoute = EdgePageModel.Route });
      }
    }
  }
}
