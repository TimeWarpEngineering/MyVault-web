namespace Shared.Features.Conversion
{
  using FluentValidation;
  using Shared;
  public class ConversionRequestValidator : AbstractValidator<ConversionRequest>
  {
    public ConversionRequestValidator()
    {
      RuleFor(aConversionRequest => aConversionRequest.FromCurrency)
        .Equals(ConversionRequest.AgldCurrencyCode);

      RuleFor(aGetNativeAmountRequest => aGetNativeAmountRequest.ToCurrency)
        .Equals(ConversionRequest.UsdCurrencyCode);

    }
  }
}
