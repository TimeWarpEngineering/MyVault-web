namespace Herc.Pwa.Client.Features.Edge.EdgeAccount
{
  using BlazorState;

  public partial class EdgeAccountState : State<EdgeAccountState>
  {
    public EdgeAccountState() { }

    public string Username { get; set; }
    public bool LoggedIn { get; set; }
    public string Id { get; set; }

    public override object Clone() => MemberwiseClone();

    protected override void Initialize() => LoggedIn = false;
  }

}