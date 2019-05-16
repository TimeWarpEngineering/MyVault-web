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

    ConversionRequest ConversionRequest = new ConversionRequest { FromCurrency = "ETH", ToCurrency = "USD" };


    public async Task WillItWork()
    {
      IDictionary<string, decimal> result = await Mediator.Send()
    }


  }
}
