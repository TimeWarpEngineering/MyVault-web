namespace Shared.Features.Application
{
  using System;
  using Shared.Features.Base;

  /// <summary>
  /// Returns the Application DTO
  /// </summary>
  public class GetApplicationResponse : BaseResponse
  {
    /// <summary>
    /// Base constructor
    /// </summary>
    public GetApplicationResponse() { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="aRequestId">Pass in the associated RequestId</param>
    public GetApplicationResponse(Guid aRequestId) : base(aRequestId) { }

    /// <summary>
    /// The Application DTO
    /// </summary>
    public ApplicationDto Application {get; set;}
}
}
