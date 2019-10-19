namespace Client.Features.Edge.EdgeAccount
{
  using BlazorState;
  using System;

  public partial class EdgeAccountState : State<EdgeAccountState>, ICloneable
  {
    public EdgeAccountState() { }

    public string Id { get; private set; }
    public bool LoggedIn { get; private set; }
    public string Username { get; private set; }

    public object Clone() => MemberwiseClone();

    public override void Initialize() => LoggedIn = false;
  }
}