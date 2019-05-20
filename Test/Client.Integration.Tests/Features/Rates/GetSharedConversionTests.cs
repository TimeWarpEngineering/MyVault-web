namespace Client.Integration.Tests.Features.Rates
{
  using System;
  using MediatR;
  using Shouldly;
  using System.Threading.Tasks;
  using Microsoft.Extensions.DependencyInjection;
  using BlazorState.Integration.Tests.Infrastructure;
  using Client.Features.Rate;
  class ClientGetRateTests
  {
    private readonly IMediator Mediator;
    private IServiceProvider ServiceProvider { get; }


    public ClientGetRateTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
    }

    //public GetRateAction GetRateAction  { get; set; } 

    public async Task GetAgldRate()
    {
      var getRateAction = new GetRateAction { FromCurrency = "AGLD", ToCurrency = "USD" };
      RateState result = await Mediator.Send(getRateAction);
      result.ShouldNotBe(null);
      Console.WriteLine(result.Rate);

    }

    public async Task GetEthRate()
    {
      var getRateAction = new GetRateAction { FromCurrency = "ETH", ToCurrency = "USD" };
      RateState result = await Mediator.Send(getRateAction);
      result.ShouldNotBe(null);
      Console.WriteLine("{ result.Rate}");

    }



  }
}
