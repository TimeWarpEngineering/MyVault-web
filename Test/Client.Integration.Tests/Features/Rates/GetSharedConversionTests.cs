namespace Client.Integration.Tests.Features.Rates
{
  using System;
  using System.Collections.Generic;
  using System.Text;
  using MediatR;
  using Shouldly;
  using System.Threading.Tasks;
  using Microsoft.Extensions.DependencyInjection;
  using BlazorState.Integration.Tests.Infrastructure;
  using Shared.Features.Conversion;
  class  GetSharedConversionTests
  {
    private IMediator Mediator;
    private IServiceProvider ServiceProvider { get; }

    public AgldRateRequest.PriceRequest PriceRequest1 => PriceRequest;

    //AgldRateRequest PriceRequest { get; } = new AgldRateRequest();
    public GetSharedConversionTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
    }

    private readonly AgldRateRequest.PriceRequest PriceRequest = new AgldRateRequest.PriceRequest();

    public async Task GetAgldRate()
    {
      ConversionResponse.PriceResponse result = await Mediator.Send(PriceRequest1);
      result.ShouldNotBeNull();
    }

    //Dictionary<string, decimal>.KeyCollection kvp = result.Prices.Keys;


  }
}

    //readonly ConversionRequest.SingleSymbolPriceRequest SingleSymbolPriceRequest = new ConversionRequest.SingleSymbolPriceRequest { fsym = "ETH", tsyms = "USD" };



    //public async Task GetEthPrice()
    //{

    //  ConversionResponse.SingleSymbolPriceResponse result = await Mediator.Send(SingleSymbolPriceRequest);

    //  result.ShouldNotBeNull();
    //  result.Prices.ContainsKey("USD").ShouldBe(true);
    //  result.Prices.Values.ShouldNotBe(null);

    //  //Dictionary<string, decimal>.KeyCollection kvp = result.Prices.Keys;


    //}




  

