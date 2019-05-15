namespace Client.Integration.Tests.Features.PriceConversion
{
  using MediatR;
  using Microsoft.Extensions.DependencyInjection;
  using Server.Services.AnthemGold.Price;
  using System;
  using System.Threading.Tasks;
  using Shouldly;
  using Server.Integration.Tests;

  public class PriceConversionTests
  {
    private IMediator Mediator;
    private IServiceProvider ServiceProvider { get; }

    public PriceConversionTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
    }
    // Arrange
    // Act

    public async Task ShouldbeAThing()
    {
      PriceResponse priceResponse = await Mediator.Send(new PriceRequest());
      Console.WriteLine(priceResponse);
      Console.WriteLine($"Price Response Close Rate: {priceResponse.C}");
      priceResponse.ShouldNotBeNull();
      priceResponse.C.ShouldBeGreaterThan(0);
      priceResponse.Ts.AddMinutes(1).ShouldBeGreaterThan(DateTime.Now);
      
    }
  }



}
