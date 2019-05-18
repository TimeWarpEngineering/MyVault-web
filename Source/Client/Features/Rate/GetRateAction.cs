namespace Client.Features.AgldRate
{
  using MediatR;

  public class AgldGetRateAction : IRequest<AgldRateState>
  {
    public decimal AgldRate { get; set; }

  }
}
