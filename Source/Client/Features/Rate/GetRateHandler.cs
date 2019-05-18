namespace Client.Features.AgldRate
{
  // I would like to have one Conversion State that has the values for both AGLD and Eth and the EdgeWallet.CurrencyCode 
  // will pick which one is used applicable.
  using BlazorState;
  using System.Threading;
  using System.Threading.Tasks;
  using Shared.Features.Conversion;
  using System.Net.Http;
  using Microsoft.AspNetCore.Components;
  using TimeWarp.Extensions;
  using Client.Features.Base;
  public partial class AgldRateState
  {
    public class AgldGetRateHandler : BaseHandler<AgldGetRateAction, AgldRateState>
    {
      public AgldGetRateHandler(IStore aStore, HttpClient aHttpClient) : base(aStore)
      {
        HttpClient = aHttpClient;
      }
      private HttpClient HttpClient { get; }

      readonly ConversionRequest conversionRequest = new ConversionRequest() { FromCurrency = "agld", ToCurrency = "usd" };

      public override async Task<AgldRateState> Handle(AgldGetRateAction aAgldGetRateAction, CancellationToken aCancellationToken)
      {

        string uri = $"{ConversionRequest.Route}?{conversionRequest.ToQueryString()}";
        ConversionResponse conversionResponse = await HttpClient.GetJsonAsync<ConversionResponse>(uri);
        AgldRateState.AgldRate = conversionResponse.Rate;

        return AgldRateState;
      }
    }
  }
}
