namespace Herc.Pwa.Client.Features.Edge.Components
{
  using System.Globalization;
  using Herc.Pwa.Client.Components;
  using Herc.Pwa.Client.Features.Edge.State;
  using Herc.Pwa.Client.Services;
  using Microsoft.AspNetCore.Components;

  public class EdgeTransactionComponentModel : BaseComponent
  {

    [Parameter] protected EdgeTransaction EdgeTransaction { get; set; }
    [Parameter] protected int DecimalPlacesToDisplay { get; set; } = 6;
    
    private int Granularity { get; set; } = 18; // multiplier is 10^18 18 places 

    public string IsoDateString => EdgeTransaction.Date.ToString("yyyy-MM-dd' T'HH:mm:ss", CultureInfo.InvariantCulture);
    public string EthScanUrl => $"https://etherscan.io/tx/{EdgeTransaction.TxId}";
    [Inject] public AmountConverter AmountConverter { get; set; }
    public string TransactionAmount
    {
      get
      {
        var balanceFormaterRequest = new FormatAmountRequest()
        {
          Amount = EdgeTransaction.NativeAmount,
          Granularity = Granularity,
          DecimalPlacesToDisplay = DecimalPlacesToDisplay,
        };
        return AmountConverter.GetFormatedAmount(balanceFormaterRequest);
      }
    }

  }
}

