namespace Client.Features.Rate
{
  using Client.Features.Base;

  public class GetRateAction : BaseAction
  {
    public string FromCurrency { get; set; }
    public string ToCurrency { get; set; }
  }
}