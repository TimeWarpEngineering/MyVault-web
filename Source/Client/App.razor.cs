namespace Client
{
  using System.Threading.Tasks;
  using BlazorState.Pipeline.ReduxDevTools;
  using BlazorState.Features.JavaScriptInterop;
  using BlazorState.Features.Routing;
  using Microsoft.AspNetCore.Components;
  using BlazorHostedCSharp.Client.Features.ClientLoader;
  using System;

  public class AppBase : ComponentBase
  {
    [Inject] private ClientLoader ClientLoader { get; set; }
    [Inject] private JsonRequestHandler JsonRequestHandler { get; set; }
    //[Inject] private ReduxDevToolsInterop ReduxDevToolsInterop { get; set; }

    // Injected so it is created by the container. Even though the ide says it is not used it is.
    [Inject] private RouteManager RouteManager { get; set; }

    protected override async Task OnAfterRenderAsync(bool aFirstRender)
    {
      //await ReduxDevToolsInterop.InitAsync();
      await JsonRequestHandler.InitAsync();
      await ClientLoader.InitAsync();
    }
  }
}