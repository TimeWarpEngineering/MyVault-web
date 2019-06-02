namespace Client.Features.Application
{
  using BlazorState;

  public partial class ApplicationState : State<ApplicationState>
  {
    public string Name { get; private set; }
    public string Version => GetType().Assembly.GetName().Version.ToString();

    protected override void Initialize() => Name = "myvault.anthemgold.com";
  }
}