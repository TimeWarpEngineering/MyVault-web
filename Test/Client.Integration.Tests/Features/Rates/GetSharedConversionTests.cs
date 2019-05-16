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

    
    public async Task WillItWork()
    {
      ConversionResponse.SingleSymbolPriceResponse result = await Mediator.Send(SingleSymbolPriceRequest);

      result.ShouldNotBeNull();

    }


  }
}
