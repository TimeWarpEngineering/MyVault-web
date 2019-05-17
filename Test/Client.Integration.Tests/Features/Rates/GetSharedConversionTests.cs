namespace Client.Integration.Tests.Features.Rates
{
  using System;
  using System.Collections.Generic;
  using System.Text;
  using MediatR;
  using Server.Services.CryptoCompare.SingleSymbolPrice;
  using Shouldly;
  using System.Threading.Tasks;
  using Microsoft.Extensions.DependencyInjection;
  using BlazorState.Integration.Tests.Infrastructure;
  using Shared.Features.Conversion;
  class GetSharedConversionTests
  {
    private IMediator Mediator;
    private IServiceProvider ServiceProvider { get; }

    public GetSharedConversionTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
    }

    readonly ConversionRequest.SingleSymbolPriceRequest SingleSymbolPriceRequest = new ConversionRequest.SingleSymbolPriceRequest { fsym = "ETH", tsyms = "USD" };

    readonly ConversionRequest.PriceRequest PriceRequest = new ConversionRequest.PriceRequest { Range = "MINUTE_5" };


    public async Task GetEthPrice()
    {

      ConversionResponse.SingleSymbolPriceResponse result = await Mediator.Send(SingleSymbolPriceRequest);

      result.ShouldNotBeNull();
      result.Prices.ContainsKey("USD").ShouldBe(true);
      result.Prices.Values.ShouldNotBe(null);

      //Dictionary<string, decimal>.KeyCollection kvp = result.Prices.Keys;


    }

    public async Task GetAGldPrice()
    {

      ConversionResponse.PriceResponse result = await Mediator.Send(PriceRequest);

      result.ShouldNotBeNull();

      //Dictionary<string, decimal>.KeyCollection kvp = result.Prices.Keys;


    }


  }
}
