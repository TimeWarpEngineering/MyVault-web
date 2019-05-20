namespace Shared.Features.Conversion
{
  using FluentValidation;
  using System.Collections.Generic;

  public class ConversionRequestValidator : AbstractValidator<ConversionRequest>
  {

    public ConversionRequestValidator()
    {
      var ValidTokens = new List<string> { "agld", "eth" };

      RuleFor(aConversionRequest => aConversionRequest.FromCurrency.ToLower())
        .Must(aToken => ValidTokens.Contains(aToken));

      RuleFor(aGetNativeAmountRequest => aGetNativeAmountRequest.ToCurrency.ToLower())
        .Equal(ConversionRequest.UsdCurrencyCode.ToLower());

    }
    

  }
}