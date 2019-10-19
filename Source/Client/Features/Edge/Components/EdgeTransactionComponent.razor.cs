namespace Client.Features.Edge.Components
{
  using System.Globalization;
  using Client.Components;
  using Client.Features.Edge.State;
  using Client.Services;
  using Microsoft.AspNetCore.Components;

  public class EdgeTransactionComponentBase : BaseComponent
  {

    [Parameter] public EdgeTransaction EdgeTransaction { get; set; }
    [Parameter] public int DecimalPlacesToDisplay { get; set; } = 6;

    [Parameter] public int Granularity { get; set; } = 18; // multiplier is 10^18 18 places 

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

