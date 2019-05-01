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
    /// Not sure if this below belongs here....
    public ConversionResponse() { }


    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="aConversionRequestId">Pass in the associated RequestId</param>
    public ConversionResponse(Guid aRequestId) 
    {
      ConversionRate = new ConversionDto();
      RequestId = aRequestId;
      
    }
    internal ConversionDto ConversionRate;
    /// <summary>
    /// The Application DTO
    /// </summary>


  }
}
