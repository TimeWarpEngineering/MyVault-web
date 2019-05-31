namespace Client.Features.Rate
{
  using MediatR;

  public class GetRateAction : IRequest<RateState>
  {
    public string FromCurrency { get; set; }
    public string ToCurrency { get; set; }

  }
}
