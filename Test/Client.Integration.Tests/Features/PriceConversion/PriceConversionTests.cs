namespace Client.Integration.Tests.Features.PriceConversion
{
  using FluentValidation;
  using FluentValidation.Results;
  using Server.Services.AnthemGold.Price;
  using System;
  using Server.Services.AnthemGold;
  using static Server.Services.AnthemGold.AnthemGoldConstants;
  public class IsValidPriceRequest
  {
    // Arrange
     static PriceRequestValidator PriceRequestValidator = new PriceRequestValidator();

    PriceRequest PriceRequest = new PriceRequest();

        // Assert


        public ValidationResult Result { get; } = PriceRequestValidator.Validate(PriceRequest);
  }



}
