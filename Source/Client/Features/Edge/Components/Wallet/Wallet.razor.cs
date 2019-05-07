namespace Client.Features.Edge.Components.Wallet
{
  using System;
  using System.Net.Http;
  using System.Threading.Tasks;
  using Client.Components;
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
    [Parameter] protected EdgeCurrencyWallet EdgeCurrencyWallet { get; set; }
    [Inject] private AmountConverter AmountConverter { get; set; }

    [Inject] protected HttpClient HttpClient { get; set; }

    public void OnClickHandler(string aCurrencyCode) => EdgeCurrencyWallet.SelectedCurrencyCode = aCurrencyCode;

    protected string FormattedBalanceForConversion => AmountConverter.GetFormatedAmount(new FormatAmountRequest { Amount = Balance, DecimalPlacesToDisplay = 2, DecimalSeperator = '.', Granularity = Granularity });

 
    //protected string FormattedRateForConversion => AmountConverter.GetFormatedAmount(new FormatAmountRequest { Amount = ConversionResponse.Rate.ToString(), DecimalPlacesToDisplay = 2, DecimalSeperator = '.', Granularity = 8 });


    protected override async Task OnInitAsync()
    {
      Console.WriteLine("WalletModel OnInitAsync");
      var conversionRequest = new ConversionRequest
      {
        FromCurrency = "agld",
        ToCurrency = "usd"
      };

      // The HttpClient.Base Address is configured before registering with the DI container.
      string uri = $"{ConversionRequest.Route}?{conversionRequest.ToQueryString()}";
      ConversionResponse = await HttpClient.GetJsonAsync<ConversionResponse>(uri);

      StateHasChanged();
    }
  }
}