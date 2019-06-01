namespace Shared.Features.Conversion
{
  using FluentValidation;
  using System.Collections.Generic;
  using static Shared.Constants.CurrencyCodes;
  public class ConversionRequestValidator : AbstractValidator<ConversionRequest>
  {

    public ConversionRequestValidator()
    {
      var validTokens = new List<string> { AgldCurrencyCode.ToLower(), EthCurrencyCode.ToLower(), AhldCurrencyCode.ToLower() };

      RuleFor(aConversionRequest => aConversionRequest.FromCurrency.ToLower())
        .Must(aToken => validTokens.Contains(aToken));

      RuleFor(aGetNativeAmountRequest => aGetNativeAmountRequest.ToCurrency.ToLower())
        .Equal(UsdCurrencyCode.ToLower());

    }
    

  }
}