namespace Client.Features.Edge.Components.Wallet
{
  using System;
  using System.Net.Http;
  using System.Threading.Tasks;
  using Client.Components;
  using Client.Features.Rate;
  using Client.Features.Edge;
  using Client.Services;
  using Microsoft.AspNetCore.Components;
  using Shared.Features.Conversion;
  using TimeWarp.Extensions;

  public class WalletBase : BaseComponent
  {
    public string Balance => EdgeCurrencyWallet.SelectedCurrencyCode != null ? EdgeCurrencyWallet?.Balances[EdgeCurrencyWallet.SelectedCurrencyCode] : null;
    public ConversionResponse ConversionResponse { get; set; }
    public string CurrencyCode => EdgeCurrencyWallet.SelectedCurrencyCode ?? "AGLD";
    public int Granularity => EdgeCurrencyWallet.Granularity[CurrencyCode];
    public EdgeCurrencyWallet EdgeCurrencyWallet => EdgeCurrencyWalletsState.SelectedEdgeCurrencyWallet;
    [Inject] private AmountConverter AmountConverter { get; set; }

    [Inject] protected HttpClient HttpClient { get; set; }

    public async Task OnClickHandler(string aCurrencyCode) => 
      _ = await Mediator.Send(new SetSelectedCurrencyAction { CurrencyCode = aCurrencyCode });

    protected string FormattedBalanceForConversion => AmountConverter.GetFormatedAmount(new FormatAmountRequest { Amount = Balance, DecimalPlacesToDisplay = 2, DecimalSeperator = '.', Granularity = Granularity });

  }
}