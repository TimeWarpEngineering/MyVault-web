namespace Client.Features.Edge.Components.Wallet
{
  using System;
  using System.Threading.Tasks;
  using Client.Components;
  using Client.Features.Edge.EdgeCurrencyWallet;
  using Microsoft.AspNetCore.Components;
  using Shared.Features.Conversion;
  //using System.Net.Http;

  public class WalletModel : BaseComponent
    {

        [Parameter] protected EdgeCurrencyWallet EdgeCurrencyWallet { get; set; }

        public string Balance => EdgeCurrencyWallet.SelectedCurrencyCode != null ? EdgeCurrencyWallet?.Balances[EdgeCurrencyWallet.SelectedCurrencyCode] : null;

        public string CurrencyCode => EdgeCurrencyWallet.SelectedCurrencyCode ?? "AGLD";

        public int Granularity => EdgeCurrencyWallet.Granularity[CurrencyCode];

        public void OnClickHandler(string aCurrencyCode) => EdgeCurrencyWallet.SelectedCurrencyCode = aCurrencyCode;

    public ConversionResponse ConversionResponse { get; set; }

    //public HttpClient HttpClient { get; set; }

        public ConversionRequest ConversionRequest { get; set; } 
                

        public void PrintStuff()
        {   ConversionRequest = new ConversionRequest("Hello", "again");

      Console.WriteLine(CurrencyCode);

            Console.WriteLine(ConversionRequest.FromCurrency);
      Console.WriteLine(ConversionRequest.ToCurrency);
      Console.WriteLine(ConversionRequest.Route);
            Console.WriteLine("Stuff!!!!");
        }

        //private Task<T> HttpClient<T>(string route, ConversionRequest conversionRequest) => throw new NotImplementedException();
        //var response = await HttpClient.SendJsonAsync<ConversionResponse>(HttpMethod.Get, "api/Conversion", ConversionRequest);
        //Console.WriteLine(response + "response here maybe");
        //          return response;
        //        }
}
  }


  //FromCurrency=AGLD&ToCurrency=USD"

  
  

