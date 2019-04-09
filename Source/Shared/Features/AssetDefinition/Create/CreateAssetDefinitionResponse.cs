namespace Herc.Pwa.Shared.Features.AssetDefinition
{
  using System;
  using Herc.Pwa.Shared.Features.Base;

  public class CreateAssetDefinitionResponse : BaseResponse
  {
    public CreateAssetDefinitionResponse() { }
    public CreateAssetDefinitionResponse(Guid aRequestId) : base(aRequestId) { }
    public AssetDefinitionDto AssetDefinition { get; set; }
  }
}