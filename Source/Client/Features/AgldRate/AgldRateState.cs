namespace Client.Features.AgldRate
{
  using BlazorState;

  public partial class AgldRateState : State<AgldRateState>
  {
    public decimal AgldRate { get; private set; }


    protected override void Initialize() => AgldRate = 0;
  }
}

