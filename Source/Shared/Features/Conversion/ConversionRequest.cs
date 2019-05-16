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
    public const string EthCurrencyCode = "ETH";

    public class SingleSymbolPriceRequest : IRequest<SingleSymbolPriceResponse>
    {
      public string tsyms { get; set; }

      public string fsym { get; set; }
    }
    public string FromCurrency { get; set; }
    public string ToCurrency { get; set; } = UsdCurrencyCode;



  }
}
