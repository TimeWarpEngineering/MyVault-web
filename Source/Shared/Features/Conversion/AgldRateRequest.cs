namespace Shared.Features.Conversion
{
  using Shared.Features.Base;
  using MediatR;
  using static Shared.Features.Conversion.ConversionResponse;
  using System;
  using static Shared.Features.Conversion.AgldRateRequest;

  /// <summary>
  /// Get the Application Object
  /// </summary>
  public class AgldRateRequest : BaseRequest, IRequest<PriceResponse>
  {
    //public const string Route = "api/Conversion";

    public const string AgldCurrencyCode = "AGLD";
    public const string UsdCurrencyCode = "USD";
    public class PriceRequest 
    {
      public string Symbol { get; set; } = $"{UsdCurrencyCode}{AgldCurrencyCode}";
      public string Range { get; set; } = "range=MINUTE_5";
      //public string FromCurrency { get; set; }
      //public string ToCurrency { get; set; } = UsdCurrencyCode;
           
    }
  }
    //public const string EthCurrencyCode = "ETH";


    //public class SingleSymbolPriceRequest : IRequest<SingleSymbolPriceResponse>
    //{
    //  public string tsyms { get; set; } = UsdCurrencyCode;

    //  public string fsym { get; set; } = EthCurrencyCode;
    //}

}