//namespace Client.Integration.Tests.Features.Rates
//{
//  using System;
//  using System.Collections.Generic;
//  using System.Text;
//  using MediatR;
//  using Shouldly;
//  using System.Threading.Tasks;
//  using Microsoft.Extensions.DependencyInjection;
//  using BlazorState.Integration.Tests.Infrastructure;
//  using Shared.Features.Conversion;
//  class  GetSharedConversionTests
//  {
//    private IMediator Mediator;
//    private IServiceProvider ServiceProvider { get; }

//    public ConversionRequest ConversionRequest;

//    //AgldRateRequest PriceRequest { get; } = new AgldRateRequest();
//    public GetSharedConversionTests(TestFixture aTestFixture)
//    {
//      ServiceProvider = aTestFixture.ServiceProvider;
//      Mediator = ServiceProvider.GetService<IMediator>();
//    }


//    public async Task GetAgldRate()
//    {
//      ConversionResponse result = await Mediator.Send(ConversionRequest);
//    }

//    //Dictionary<string, decimal>.KeyCollection kvp = result.Prices.Keys;


//  }
//}

//    //readonly ConversionRequest.SingleSymbolPriceRequest SingleSymbolPriceRequest = new ConversionRequest.SingleSymbolPriceRequest { fsym = "ETH", tsyms = "USD" };



//    //public async Task GetEthPrice()
//    //{

//    //  ConversionResponse.SingleSymbolPriceResponse result = await Mediator.Send(SingleSymbolPriceRequest);

//    //  result.ShouldNotBeNull();
//    //  result.Prices.ContainsKey("USD").ShouldBe(true);
//    //  result.Prices.Values.ShouldNotBe(null);

//    //  //Dictionary<string, decimal>.KeyCollection kvp = result.Prices.Keys;


//    //}




  

