namespace Herc.Pwa.Server.Features.AssetDefinition
{
  using System.Threading.Tasks;
  using Herc.Pwa.Server.Features.Base;
  using Herc.Pwa.Shared.Features.AssetDefinition;
  using MediatR;
  using Microsoft.AspNetCore.Mvc;

  [Route(GetAssetDefinitionRequest.Route)]
  public class GetAssetDefinitionController : BaseController<GetAssetDefinitionRequest, GetAssetDefinitionResponse>
  {
    public GetAssetDefinitionController(IMediator aMediator) : base(aMediator) { }
    
    [HttpGet]
    public async Task<IActionResult> Process(GetAssetDefinitionRequest aGetAssetDefinitionRequest) => await Send(aGetAssetDefinitionRequest);
  }
}
