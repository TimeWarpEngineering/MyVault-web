namespace Herc.Pwa.Server.Features.Application.Get
{
  using System.Threading.Tasks;
  using Herc.Pwa.Server.Features.Base;
  using Herc.Pwa.Shared.Features.Application;
  using MediatR;
  using Microsoft.AspNetCore.Mvc;

  [Route(GetApplicationRequest.Route)]
  public class GetApplicationController : BaseController<GetApplicationRequest, GetApplicationResponse>
  {
    public GetApplicationController(IMediator aMediator) : base(aMediator) { }

    [HttpPost]
    public async Task<IActionResult> Post(GetApplicationRequest aRequest) => await Send(aRequest);
  }
}
