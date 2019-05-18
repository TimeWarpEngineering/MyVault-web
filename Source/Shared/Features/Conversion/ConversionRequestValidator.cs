namespace Shared.Features.Conversion
{
  using FluentValidation;
  public class ConversionRequestValidator : AbstractValidator<ConversionRequest>
{
  public ConversionRequestValidator()
  {
    RuleFor(aConversionRequest => aConversionRequest.FromCurrency.ToLower())
      .Equal(ConversionRequest.AgldCurrencyCode.ToLower());

    RuleFor(aGetNativeAmountRequest => aGetNativeAmountRequest.ToCurrency.ToLower())
      .Equal(ConversionRequest.UsdCurrencyCode.ToLower());

  }
}
}