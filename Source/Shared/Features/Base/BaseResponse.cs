namespace Shared.Features.Base
{
  using System;

  public abstract class BaseResponse
  {
    public BaseResponse(Guid aRequestId) : this()
    {
      RequestId = aRequestId;
    }

    public BaseResponse()
    {
      ResponseId = Guid.NewGuid();
    }

    /// <summary>
    /// The RequestId. Used to correlate request and response
    /// </summary>
    public Guid RequestId { get; set; }

    /// <summary>
    /// The ResponseId. Used to correlate request and response
    /// </summary>
    public Guid ResponseId { get; }
  }
}