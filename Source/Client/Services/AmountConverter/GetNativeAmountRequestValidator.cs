namespace Herc.Pwa.Client.Services
{
  using FluentValidation;
  using Herc.Pwa.Shared;
  using System.Linq;

  public class GetNativeAmountRequestValidator : AbstractValidator<GetNativeAmountRequest>
  {
    public GetNativeAmountRequestValidator()
    {
      RuleFor(aGetNativeAmountRequest => aGetNativeAmountRequest.Amount)
        .NotEmpty()
        .Matches((aGetNativeAmountRequest) => RegularExpressions.FloatingPointNumberNoSign(aGetNativeAmountRequest.DecimalSeperator));

      RuleFor(aGetNativeAmountRequest => aGetNativeAmountRequest.DecimalSeperator)
        .NotEmpty();

      RuleFor(aGetNativeAmountRequest => aGetNativeAmountRequest.Granularity)
        .NotEmpty()
        .GreaterThan(0);
    }
  }
}
