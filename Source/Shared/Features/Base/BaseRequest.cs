namespace Shared.Features.Base
{
  using System;

  public abstract class BaseRequest
  {
    /// <summary>
    /// Every request should have unique Id
    /// </summary>
    public BaseRequest()
    {
      Guid = Guid.NewGuid();
    }

    public Guid Guid { get; }
  }
}
