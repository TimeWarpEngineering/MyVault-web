namespace Shared.Features.Conversion
{
  using System;
  using Shared.Features.Base;


  /// <summary>
  /// Returns the Application DTO
  /// </summary>
  public class ConversionResponse : BaseResponse
  {
    private ConversionRate aConversionRate;

    /// <summary>
    /// Base constructor
    /// </summary>
    /// Not sure if this below belongs here....
    public ConversionResponse() { }


    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="aConversionRequestId">Pass in the associated RequestId</param>
    public ConversionResponse(Guid aRequestId) 
    {
      aConversionRate = new ConversionRate();
      
    }
    internal class ConversionRate
    {
      public string CurrencyA { get; set; }
      public string CurrencyB { get; set; }
      public double Rate { get; set; }
    }
    /// <summary>
    /// The Application DTO
    /// </summary>


  }
}
