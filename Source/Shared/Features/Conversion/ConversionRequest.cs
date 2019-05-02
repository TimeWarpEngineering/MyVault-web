namespace Shared.Features.Conversion
{
  using Shared.Features.Base;
  using MediatR;

  /// <summary>
  /// Get the Application Object
  /// </summary>
  public class ConversionRequest : BaseRequest, IRequest<ConversionResponse>
  {
    public const string Route = "api/Conversion";

    public const string AgldCurrencyCode = "AGLD";
    public const string UsdCurrencyCode = "USD";
   
    public string FromCurrency { get; set; }
    public string ToCurrency { get; set; }

    public ConversionRequest(string aFromCurrency1, string aToCurrency1)
    {
      FromCurrency = aFromCurrency1;
      ToCurrency = aToCurrency1;
    }

    public ConversionRequest()
    {
    }
  }
}
