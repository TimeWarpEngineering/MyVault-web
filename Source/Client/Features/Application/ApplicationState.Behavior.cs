namespace Client.Features.Application
{
  using BlazorState;

  public partial class ApplicationState : State<ApplicationState>
  {
    public ApplicationState() { }

    protected ApplicationState(ApplicationState aState) : this()
    {
      Name = aState.Name;
    }

   
    protected override void Initialize() => Name = "myvault.anthemgold.com";
  }
}