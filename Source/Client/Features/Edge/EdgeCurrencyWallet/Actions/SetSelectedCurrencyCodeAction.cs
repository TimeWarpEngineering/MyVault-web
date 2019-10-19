namespace Client.Features.Edge
{
  using Client.Features.Base;

  public class SetSelectedCurrencyAction : BaseAction
  {
    public string CurrencyCode { get; set; }
  }
}