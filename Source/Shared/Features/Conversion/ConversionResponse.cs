namespace Shared.Features.Conversion
{
  using System;
  using Shared.Features.Base;

  /// <summary>
  /// Returns the Application DTO
  /// </summary>
  public class ConversionResponse : BaseResponse
  {
    /// <summary>
    /// Base constructor
    /// </summary>
    public ConversionResponse() { }
    public string CurrencyA { get; set; }
    public string CurrencyB { get; set; }
    public double Rate { get; set; }
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="aConversionRequestId">Pass in the associated RequestId</param>
    public ConversionResponse(Guid aRequestId) : base(aRequestId)

    {
      CurrencyA = CurrencyA;
      CurrencyB = CurrencyB;
      Rate = Rate;
    }

    /// <summary>
    /// The Application DTO
    /// </summary>
    

  }
}
