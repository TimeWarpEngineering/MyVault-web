namespace Client.Features.Edge.Components.Wallet
{
  using System;
  using System.Net.Http;
  using System.Threading.Tasks;
  using Client.Components;
  using Client.Features.Rate;
  using Client.Features.Edge.EdgeCurrencyWallet;
  using Client.Services;
  using Microsoft.AspNetCore.Components;
  using Shared.Features.Conversion;
  using TimeWarp.Extensions;

  public class WalletModel : BaseComponent
  {
    public string Balance => EdgeCurrencyWallet.SelectedCurrencyCode != null ? EdgeCurrencyWallet?.Balances[EdgeCurrencyWallet.SelectedCurrencyCode] : null;
    public ConversionResponse ConversionResponse { get; set; }
    public string CurrencyCode => EdgeCurrencyWallet.SelectedCurrencyCode ?? "AGLD";
    public int Granularity => EdgeCurrencyWallet.Granularity[CurrencyCode];
    public EdgeCurrencyWallet EdgeCurrencyWallet => EdgeCurrencyWalletsState.SelectedEdgeCurrencyWallet;
    [Inject] private AmountConverter AmountConverter { get; set; }

    [Inject] protected HttpClient HttpClient { get; set; }

    public void OnClickHandler(string aCurrencyCode)
    {

      EdgeCurrencyWallet.SelectedCurrencyCode = aCurrencyCode;
    }

    protected string FormattedBalanceForConversion => AmountConverter.GetFormatedAmount(new FormatAmountRequest { Amount = Balance, DecimalPlacesToDisplay = 2, DecimalSeperator = '.', Granularity = Granularity });


    //protected string FormattedRateForConversion => AmountConverter.GetFormatedAmount(new FormatAmountRequest { Amount = ConversionResponse.Rate.ToString(), DecimalPlacesToDisplay = 2, DecimalSeperator = '.', Granularity = 8 });


    //protected override async Task OnInitAsync() => await Mediator.Send(new AgldGetRateAction());
  }
}