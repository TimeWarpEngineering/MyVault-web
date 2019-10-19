namespace Client.Features.Edge.Components.Wallet
{
  using Client.Components;
  using Client.Services;
  using Microsoft.AspNetCore.Components;


  public class BalanceBase : BaseComponent
  {
    [Parameter] public string Balance { get; set; }

    [Parameter] public string CurrencyCode { get; set; }

    [Inject] public AmountConverter AmountConverter { get; set; }

    [Parameter] public int Granularity { get; set; } = 18; // 10^X
    [Parameter] public int DecimalPlacesToDisplay { get; set; } = 18;


    public string DisplayBalance
    {
      get
      {
        var balanceFormaterRequest = new FormatAmountRequest()
        {
          Amount = Balance,
          Granularity = Granularity,
          DecimalPlacesToDisplay = DecimalPlacesToDisplay,
        };
        return AmountConverter.GetFormatedAmount(balanceFormaterRequest);
      }
    }
  }
}
