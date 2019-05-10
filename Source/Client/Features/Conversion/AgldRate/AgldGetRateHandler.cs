﻿using BlazorState;
using System.Threading;
using System.Threading.Tasks;
using Shared.Features.Conversion;
using System.Net.Http;
using Microsoft.AspNetCore.Components;
// I would like to have one Conversion State that has the values for both AGLD and Eth and the EdgeWallet.CurrencyCode 
// will pick which one is used applicable.
namespace Client.Features.Conversion.AgldRate
{
  public partial class AgldRateState
  {
    public class AgldGetRateHandler : RequestHandler<AgldGetRateAction, AgldRateState>
    {
      public AgldGetRateHandler(IStore aStore, HttpClient aHttpClient) : base(aStore)
      {
        HttpClient = aHttpClient;
      }
      private HttpClient HttpClient { get; }
      //AgldRateState AgldRateState => Store.GetState<AgldRateState>();
      ConversionRequest ConversionRequest = new ConversionRequest() { FromCurrency = "agld", ToCurrency = "usd" };

      public override async Task<AgldRateState> Handle(AgldGetRateAction aAgldGetRateAction, CancellationToken ACancellationToken)
      {

        ConversionResponse ConversionResponse = await HttpClient.GetJsonAsync<ConversionResponse>(ConversionRequest.Route);


      }


    }
  }
}
