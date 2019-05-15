namespace Server.Integration.Tests.Services.CryptoCompare
{
  using MediatR;
  using Server.Services.CryptoCompare.SingleSymbolPrice;
  using Shouldly;
  using System;
  using System.Threading.Tasks;
  using Microsoft.Extensions.DependencyInjection;
  class SingleSymbolPriceConversionTests
  {
    private IMediator Mediator;
    private IServiceProvider ServiceProvider { get; }

    public SingleSymbolPriceConversionTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
    }
    // Arrange
    // Act

    public async Task ShouldbeAThing()
    {
      SingleSymbolPriceResponse singleSymbolPriceResponse = await Mediator.Send(new SingleSymbolPriceRequest { tsyms = "USD", fsym = "ETH" });
      Console.WriteLine(singleSymbolPriceResponse?.Prices);
      singleSymbolPriceResponse.ShouldNotBeNull();
      singleSymbolPriceResponse.Prices["USD"].ShouldBeGreaterThan(0);


      //singleSymbolPriceResponse.ShouldBeGreaterThan(0);
      //singleSymbolPriceResponses.AddMinutes(1).ShouldBeGreaterThan(DateTime.Now);

    }
  }
}

