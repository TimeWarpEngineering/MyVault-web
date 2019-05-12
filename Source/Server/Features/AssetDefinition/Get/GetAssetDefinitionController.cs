namespace Server.Features.AssetDefinition
{
  using System.Threading.Tasks;
  using Server.Features.Base;
  using Shared.Features.AssetDefinition;
  using MediatR;
  using Microsoft.AspNetCore.Mvc;

  [Route(GetAssetDefinitionRequest.Route)]
  public class GetAssetDefinitionController : BaseController<GetAssetDefinitionRequest, GetAssetDefinitionResponse>
  {
    
    [HttpGet]
    public async Task<IActionResult> Process(GetAssetDefinitionRequest aGetAssetDefinitionRequest) => await Send(aGetAssetDefinitionRequest);
  }
}
