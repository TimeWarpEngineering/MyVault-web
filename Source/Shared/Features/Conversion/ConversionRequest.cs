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

    public const string EthCurrencyCode = CurrencyCodes.EthCurrencyCode;
    public const string AgldCurrencyCode = CurrencyCodes.AgldCurrencyCode;
    public const string UsdCurrencyCode = CurrencyCodes.UsdCurrencyCode;
    public const string AhldCurrencyCode = CurrencyCodes.AhldCurrencyCode;

    public string FromCurrency { get; set; }
    public string ToCurrency { get; set; }
  }
}
