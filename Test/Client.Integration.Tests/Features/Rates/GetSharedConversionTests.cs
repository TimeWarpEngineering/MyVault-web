namespace Client.Integration.Tests.Features.Rates
{
  using BlazorState;
  using BlazorState.Integration.Tests.Infrastructure;
  using Client.Features.Rate;
  using MediatR;
  using Microsoft.Extensions.DependencyInjection;
  using Shouldly;
  using System;
  using System.Threading.Tasks;

  internal class ClientGetRateTests
  {
    private readonly IMediator Mediator;

    private readonly IStore Store;

    public ClientGetRateTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
      Store = ServiceProvider.GetService<IStore>();
    }

    private IServiceProvider ServiceProvider { get; }
    //public GetRateAction GetRateAction  { get; set; }

    public async Task GetAgldRate()
    {
      var getRateAction = new GetRateAction { FromCurrency = "AGLD", ToCurrency = "USD" };
      _ = await Mediator.Send(getRateAction);
      RateState result = Store.GetState<RateState>();
      result.ShouldNotBe(null);
      result.Conversions.Count.ShouldBeGreaterThan(0);
      RateState.Conversion conversion = result.GetConversion("AGLD", "USD");
      conversion.ShouldNotBeNull();
      // TODO add more asserts
    }

    public async Task GetEthRate()
    {
      var getRateAction = new GetRateAction { FromCurrency = "ETH", ToCurrency = "USD" };
      _ = await Mediator.Send(getRateAction);
      RateState result = Store.GetState<RateState>();
      result.ShouldNotBe(null);
      Console.WriteLine("{ result.Rate}");
    }
  }
}