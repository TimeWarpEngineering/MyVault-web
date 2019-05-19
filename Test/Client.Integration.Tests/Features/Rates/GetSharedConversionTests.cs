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
  using Client.Features.Rate;
  class ClientGetRateTests
  {
    private IMediator Mediator;
    private IServiceProvider ServiceProvider { get; }

    public GetRateAction GetRateAction  { get; } = new GetRateAction { FromCurrency = "AGLD", ToCurrency = "USD" };

    public ClientGetRateTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
    }


    public async Task GetAgldRate()
    {
      RateState result = await Mediator.Send(GetRateAction);
      result.ShouldNotBe(null);

    }



  }
}




//public async Task GetEthPrice()
//{

//  ConversionResponse.SingleSymbolPriceResponse result = await Mediator.Send(SingleSymbolPriceRequest);

//  result.ShouldNotBeNull();
//  result.Prices.ContainsKey("USD").ShouldBe(true);
//  result.Prices.Values.ShouldNotBe(null);

//  //Dictionary<string, decimal>.KeyCollection kvp = result.Prices.Keys;


//}






