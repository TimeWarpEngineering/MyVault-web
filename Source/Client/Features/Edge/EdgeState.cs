namespace Client.Features.Edge
{
  using BlazorState;

  public partial class EdgeState : State<EdgeState>
  {
    public EdgeWalletInfo EdgeWalletInfo { get; set; }
    protected override void Initialize() => EdgeWalletInfo = null;
  }
}