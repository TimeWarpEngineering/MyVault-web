namespace Client.Features.Edge.Components.Wallet
{
  using System.Collections.Generic;
  using System.Threading.Tasks;
  using Client.Components;
  using Client.Features.Edge.EdgeCurrencyWallet;
  using Client.Features.Edge.State;
  using Microsoft.AspNetCore.Components;
  using Shared.Features.Conversion;
    using Blazor;

    public class WalletModel : BaseComponent
    {

        [Parameter] protected EdgeCurrencyWallet EdgeCurrencyWallet { get; set; }


        public string Balance => EdgeCurrencyWallet.SelectedCurrencyCode != null ? EdgeCurrencyWallet?.Balances[EdgeCurrencyWallet.SelectedCurrencyCode] : null;

        public string CurrencyCode => EdgeCurrencyWallet.SelectedCurrencyCode ?? "AGLD";

        public int Granularity => EdgeCurrencyWallet.Granularity[CurrencyCode];

        public void OnClickHandler(string aCurrencyCode) => EdgeCurrencyWallet.SelectedCurrencyCode = aCurrencyCode;

        public ConversionResponse ConversionResponse { get; set; }

        public ConversionRequest ConversionRequest
        {
            get
            {
                ConversionRequest.FromCurrency = CurrencyCode;
                ConversionRequest.ToCurrency = "usd";
                return ConversionRequest;
            }

        }

        protected override async Task OnInitAsync()
        {
            ConversionResponse = await HttpClient<ConversionResponse>(ConversionRequest.Route, ConversionRequest);
        }

    }
  }


  //FromCurrency=AGLD&ToCurrency=USD"

  
  

