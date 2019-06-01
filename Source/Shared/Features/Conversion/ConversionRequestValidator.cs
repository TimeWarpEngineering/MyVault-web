namespace Shared.Features.Conversion
{
  using FluentValidation;
  using System.Collections.Generic;

  public class ConversionRequestValidator : AbstractValidator<ConversionRequest>
  {

    public ConversionRequestValidator()
    {
      var validTokens = new List<string> { CurrencyCodes.AgldCurrencyCode.ToLower(), CurrencyCodes.EthCurrencyCode.ToLower(), CurrencyCodes.AhldCurrencyCode.ToLower() };

      RuleFor(aConversionRequest => aConversionRequest.FromCurrency.ToLower())
        .Must(aToken => validTokens.Contains(aToken));

      RuleFor(aGetNativeAmountRequest => aGetNativeAmountRequest.ToCurrency.ToLower())
        .Equal(ConversionRequest.UsdCurrencyCode.ToLower());

    }
    

  }
}