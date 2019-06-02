namespace Client.Features.Edge.Components.Wallet
{
  using Client.Components;
  using Client.Services;
  using Microsoft.AspNetCore.Components;


  public class BalanceModel : BaseComponent
  {
    [Parameter] protected string Balance { get; set; }

    [Parameter] protected string CurrencyCode { get; set; }

    [Inject] public AmountConverter AmountConverter { get; set; }
    
    [Parameter] protected int Granularity { get; set; } = 18; // multiplier is 10^X
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
