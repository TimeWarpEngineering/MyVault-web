﻿namespace Shared.Features.Conversion
{
  using Shared.Features.Base;
  using MediatR;

  /// <summary>
  /// Get the Application Object
  /// </summary>
  public class ConversionRequest : BaseRequest, IRequest<ConversionRequest>
  {
    public const string Route = "api/Conversion";

  }
}
