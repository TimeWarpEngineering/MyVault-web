namespace Client.Integration.Tests.Features.PriceConversion
{
  using MediatR;
  using Microsoft.Extensions.DependencyInjection;
  using Server.Services.AnthemGold.Price;
  using System;
  using BlazorState.Integration.Tests.Infrastructure;
  using System.Threading.Tasks;
  using Shouldly;

  public class IsValidPriceRequest
  {
    private IMediator Mediator;
    private IServiceProvider ServiceProvider { get; }

    public IsValidPriceRequest(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
    }
    // Arrange
    // Act

    public async Task ShouldBeValid()
    {
      PriceResponse priceResponse = await Mediator.Send(new PriceRequest());
      Console.WriteLine(priceResponse);
      Console.WriteLine($"Price Response Close Rate: {priceResponse.C}");
      priceResponse.ShouldNotBeNull();
    }
  }



}
