﻿# nullable enable
namespace Client.Features.Rate
{
  using BlazorState;
  using System.Threading;
  using System.Threading.Tasks;
  using Shared.Features.Conversion;
  using System.Net.Http;
  using Microsoft.AspNetCore.Components;
  using TimeWarp.Extensions;
  using Client.Features.Base;
  using System.Linq;
  using MediatR;

  public partial class RateState
  {
    public class GetRateHandler : BaseHandler<GetRateAction>
    {
      public GetRateHandler(IStore aStore, HttpClient aHttpClient) : base(aStore)
      {
        HttpClient = aHttpClient;
      }
      private HttpClient HttpClient { get; }


      public override async Task<Unit> Handle(GetRateAction aGetRateAction, CancellationToken aCancellationToken)
      {
        var conversionRequest = new ConversionRequest() { FromCurrency = aGetRateAction.FromCurrency, ToCurrency = aGetRateAction.ToCurrency };
        string uri = $"{ConversionRequest.Route}?{conversionRequest.ToQueryString()}";
        ConversionResponse conversionResponse = await HttpClient.GetJsonAsync<ConversionResponse>(uri);
        Conversion? conversion = RateState.Conversions.FirstOrDefault
        (
          aConversion => aConversion.FromCurrency == aGetRateAction.FromCurrency 
            && aConversion.ToCurrency == aGetRateAction.ToCurrency
        );

        RateState._Conversions.Remove(conversion);
        RateState._Conversions.Add(new Conversion(
          conversionRequest.FromCurrency,
          conversionRequest.ToCurrency,
          conversionResponse.Rate));

        return Unit.Value;
      }
    }
  }
}
