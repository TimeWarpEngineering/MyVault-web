namespace Client.Features.Edge.Components.Wallet
{
  using System.Threading.Tasks;
  using Client.Components;
  using Client.Features.Edge.EdgeCurrencyWallet;
  using Microsoft.AspNetCore.Components;
  using Shared.Features.Conversion;
  using System.Net.Http;

  public class WalletModel : BaseComponent
    {

        [Parameter] protected EdgeCurrencyWallet EdgeCurrencyWallet { get; set; }

        public string Balance => EdgeCurrencyWallet.SelectedCurrencyCode != null ? EdgeCurrencyWallet?.Balances[EdgeCurrencyWallet.SelectedCurrencyCode] : null;

        public string CurrencyCode => EdgeCurrencyWallet.SelectedCurrencyCode ?? "AGLD";

        public int Granularity => EdgeCurrencyWallet.Granularity[CurrencyCode];

        public void OnClickHandler(string aCurrencyCode) => EdgeCurrencyWallet.SelectedCurrencyCode = aCurrencyCode;

        public ConversionResponse ConversionResponse { get; set; }

        private HttpClient HttpClient { get; set; }

        public ConversionRequest ConversionRequest
        {
            get
            {
                ConversionRequest.FromCurrency = CurrencyCode;
                ConversionRequest.ToCurrency = "usd";
                return ConversionRequest;
            }

        }

    protected override async Task OnInitAsync() => ConversionResponse = await HttpClient.SendJsonAsync<ConversionResponse>(HttpMethod.Get, ConversionRequest.Route, ConversionRequest);

    //private Task<T> HttpClient<T>(string route, ConversionRequest conversionRequest) => throw new NotImplementedException();
  }
  }


  //FromCurrency=AGLD&ToCurrency=USD"

  
  

