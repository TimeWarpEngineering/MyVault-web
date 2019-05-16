namespace Shared.Features.Conversion
{
  using FluentValidation;
  using Shared;
  using Shared.Features.Conversion;

  public class Conversionrequestvalidator : AbstractValidator<ConversionRequest.PriceRequest>
  {
    public Conversionrequestvalidator()
    {
      //rulefor(aConversionRequest.PriceRequest => aconversionrequestP.symbol.tolower())
      //  .equal(conversionrequest.agldcurrencycode + conversionrequest.usdcurrencycode.tolower());

      //rulefor(agetnativeamountrequest => agetnativeamountrequest.tocurrency.tolower())
      //  .equal(tolower());

    }
  }
}
