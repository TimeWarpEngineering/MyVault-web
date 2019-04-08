namespace Herc.Pwa.Shared.Features.AssetDefinition
{
  using Herc.Pwa.Shared.Features.Base;
  using MediatR;

  public class CreateAssetDefinitionRequest : BaseRequest, IRequest<CreateAssetDefinitionResponse>
  {
    public const string Route = "api/CreateAssetDefinition";
    /// <summary>
    /// The AssetDefintionDto which reflects the AssetDefintion you wish the create
    /// </summary>
    public AssetDefinitionDto AssetDefinitionDto { get; set; }
  }
}