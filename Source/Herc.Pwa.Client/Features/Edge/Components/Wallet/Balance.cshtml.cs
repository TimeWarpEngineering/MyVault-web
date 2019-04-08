namespace Herc.Pwa.Client.Features.Edge.Components.Wallet
{
  using Herc.Pwa.Client.Components;
  using Herc.Pwa.Client.Services;
  using Microsoft.AspNetCore.Components;

  public class BalanceModel : BaseComponent
  {
    [Parameter] protected string Balance { get; set; }

    [Parameter] protected string CurrencyCode { get; set; }

    [Inject] public AmountConverter AmountConverter { get; set; }
    private int Granularity => 18; // multiplier is 10^18 18 places 
    [Parameter] protected int DecimalPlacesToDisplay { get; set; } = 18;
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
