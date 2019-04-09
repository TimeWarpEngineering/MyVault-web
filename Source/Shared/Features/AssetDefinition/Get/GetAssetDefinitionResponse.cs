namespace Shared.Features.AssetDefinition
{
  using System;
  using Shared.Features.Base;

  /// <summary>
  /// Returns the AssetDefinitionDto if found
  /// </summary>
  public class GetAssetDefinitionResponse : BaseResponse
  {
    public GetAssetDefinitionResponse() { }
    public GetAssetDefinitionResponse(Guid aRequestId) : base(aRequestId) { }

    /// <summary>
    /// The AssetDefintion requested if found else null.
    /// </summary>
    public AssetDefinitionDto AssetDefinition { get; set; }
  }
}
