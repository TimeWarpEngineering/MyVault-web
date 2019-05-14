namespace Client.Integration.Tests.Features.PriceConversion
{
  using MediatR;
  using Microsoft.Extensions.DependencyInjection;
  using System.Collections.Generic;
  using FluentValidation;
  using FluentValidation.Results;
  using Server.Services.AnthemGold.Price;
  using System;
  using Server.Services.AnthemGold;
  using static Server.Services.AnthemGold.AnthemGoldConstants;
  using BlazorState.Integration.Tests.Infrastructure;

  public class IsValidPriceRequest
  {
    //public PriceResponse priceResponse;
    private static PriceRequest priceRequest;
    private static IMediator Mediator;
    private IServiceProvider ServiceProvider { get; }

    public IsValidPriceRequest(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
      priceRequest = new PriceRequest();
      //priceResponse = new PriceResponse();
    }
    // Arrange
    // Act

     PriceResponse priceResponse = Mediator.Send(priceRequest);

    // static PriceRequestValidator PriceRequestValidator = new PriceRequestValidator();

    //PriceRequest PriceRequest = new PriceRequest();

    //    // Assert


    //    public ValidationResult Result { get; } = PriceRequestValidator.Validate(instance: PriceRequest);
  }



}
