namespace Herc.Pwa.Shared.Features.Application
{
  using Herc.Pwa.Shared.Features.Base;
  using MediatR;

  /// <summary>
  /// Get the Application Object
  /// </summary>
  public class GetApplicationRequest : BaseRequest, IRequest<GetApplicationResponse>
  {
    public const string Route = "api/GetApplication";
  }
}
