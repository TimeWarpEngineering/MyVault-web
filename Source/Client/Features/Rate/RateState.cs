namespace Client.Features.Rate
{ 
  using BlazorState;

  public partial class RateState : State<RateState>
  {
    public decimal Rate { get; private set; }


    protected override void Initialize() => Rate = 0;
  }
}

