namespace Client.Features.Edge
{
  using System;
  using System.Collections.Generic;
  using BlazorState;

  public partial class EdgeState : State<EdgeState>
  {
    public EdgeState() { }

    protected EdgeState(EdgeState aState) : this()
    {
      EdgeWalletInfo = EdgeWalletInfo?.Clone() as EdgeWalletInfo;
    }

    public override object Clone() => new EdgeState(this);

    protected override void Initialize()
    {
      EdgeWalletInfo = null;
    }
  }

}