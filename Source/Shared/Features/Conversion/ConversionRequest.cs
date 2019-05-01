namespace Shared.Features.Conversion
{
  using Shared.Features.Base;
  using MediatR;

  /// <summary>
  /// Get the Application Object
  /// </summary>
  public class ConversionRequest : BaseRequest, IRequest<ConversionResponse>
  {
    public const string Route = @"https://chart.anthemgold.com/service-1.0-SNAPSHOT/PRICE?symbol=USDAGLD&range=MINUTE_5";

    internal class ConversionResult
    {
      public string CurrencyA { get; set; }
      public string CurrencyB { get; set; }
      public double Rate { get; set; }
    }
  }
}
