namespace Client.Integration.Tests.Features.PriceConversion
{
  using FluentValidation.Results;
  using Server.Services.AnthemGold.Price;
  using System;
  using static Server.Services.AnthemGold.AnthemGoldConstants;
  public class IsValidPriceRequest
  {
    // Arrange

    readonly PriceRequest priceRequest = new PriceRequest();

    PriceRequestValidator priceRequestValdiator = new PriceRequestValidator();
    
    // Assert
    PriceRequestValidator priceRequestValidator { get; set; }

    public ValidationResult Result => result;

    readonly ValidationResult result = priceRequestValidator.Validate(priceRequest)

  }



}
