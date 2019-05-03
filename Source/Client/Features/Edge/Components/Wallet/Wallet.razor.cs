namespace Client.Features.Edge.Components.Wallet
{
  using System;
  using System.Net.Http;
  using System.Threading.Tasks;
  using Client.Components;
  using Client.Features.Edge.EdgeCurrencyWallet;
  using Microsoft.AspNetCore.Components;
  using Shared.Features.Conversion;


  public class WalletModel : BaseComponent
    {

        [Parameter] protected EdgeCurrencyWallet EdgeCurrencyWallet { get; set; }

        private HttpClient HttpClient { get; }
        public string Balance => EdgeCurrencyWallet.SelectedCurrencyCode != null ? EdgeCurrencyWallet?.Balances[EdgeCurrencyWallet.SelectedCurrencyCode] : null;

        public string CurrencyCode => EdgeCurrencyWallet.SelectedCurrencyCode ?? "AGLD";

        public int Granularity => EdgeCurrencyWallet.Granularity[CurrencyCode];

        public void OnClickHandler(string aCurrencyCode) => EdgeCurrencyWallet.SelectedCurrencyCode = aCurrencyCode;

        public ConversionResponse ConversionResponse { get; set; }

        public ConversionRequest aConversionRequest { get; set; }


        public async Task PrintStuff()
        {
        ConversionResponse = new ConversionResponse();
            aConversionRequest = new ConversionRequest("agld", "usd");
          Console.WriteLine(aConversionRequest.ToCurrency + "theConversionrequest");
           Console.WriteLine(ConversionRequest.Route + "conversion route");


        ConversionResponse = await HttpClient.SendJsonAsync<ConversionResponse>(HttpMethod.Get, HttpClient, ConversionRequest.Route, aConversionRequest);
            Console.WriteLine(ConversionResponse.Rate + "response");
            

        }

        //private Task<T> HttpClient<T>(string route, ConversionRequest conversionRequest) => throw new NotImplementedException();
        //var response = await HttpClient.SendJsonAsync<ConversionResponse>(HttpMethod.Get, "api/Conversion", ConversionRequest);
        //Console.WriteLine(response + "response here maybe");
        //          return response;
        //        }
  }
}


  //FromCurrency=AGLD&ToCurrency=USD"

  
  

