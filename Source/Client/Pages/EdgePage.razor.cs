namespace Client.Pages
{
  using Client.Components;
  using System;
  using System.Threading.Tasks;
  using static Client.Features.Edge.EdgeState;

  public class EdgePageBase : BaseComponent
  {
    public const string Route = "edge";

    public EdgePageBase()
    {
      Console.WriteLine("EdgeModel constructor");
    }

    protected override async Task OnAfterRenderAsync(bool aFirstRender)
    {
      Console.WriteLine("EdgeModel.OnAfterRenderAsync");
      Console.WriteLine(typeof(OnLoginAction).AssemblyQualifiedName);
      await InitializeEdge();
      await ShowLoginWindow();
      Console.WriteLine("After ShowLoginWindow");
    }

    public async Task InitializeEdge()
    {
      Console.WriteLine("InitializeEdge");
      await Mediator.Send(new InitailizeEdgeAction());
      Console.WriteLine("Edge Initialized");
    }

    public async Task ShowLoginWindow()
    {
      Console.WriteLine("ShowLoginWindow Page.cs");
      await Mediator.Send(new ShowLoginWindowEdgeAction());
    }
  }
}