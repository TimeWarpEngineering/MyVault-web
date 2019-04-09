namespace Server.Features.AssetDefinition
{
  using System.Threading.Tasks;
  using Server.Features.Base;
  using Shared.Features.AssetDefinition;
  using MediatR;
  using Microsoft.AspNetCore.Mvc;

  [Route(CreateAssetDefinitionRequest.Route)]
  public class AssetDefinitionController : BaseController<CreateAssetDefinitionRequest, CreateAssetDefinitionResponse>
  {
    public AssetDefinitionController(IMediator aMediator) : base(aMediator) { }

    [HttpPost]
    public async Task<IActionResult> Post(CreateAssetDefinitionRequest aRequest) => await Send(aRequest);
  }
}