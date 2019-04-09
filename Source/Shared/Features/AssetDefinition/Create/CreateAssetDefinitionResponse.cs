namespace Shared.Features.AssetDefinition
{
  using System;
  using Shared.Features.Base;

  public class CreateAssetDefinitionResponse : BaseResponse
  {
    public CreateAssetDefinitionResponse() { }
    public CreateAssetDefinitionResponse(Guid aRequestId) : base(aRequestId) { }
    public AssetDefinitionDto AssetDefinition { get; set; }
  }
}