namespace Herc.Pwa.Shared.Features.AssetDefinition
{
  using FluentValidation;

  public class GetAssetDefinitionRequestValidator : AbstractValidator<GetAssetDefinitionRequest>
  {
    public GetAssetDefinitionRequestValidator()
    {
      RuleFor(aGetAssetDefinitionRequest => aGetAssetDefinitionRequest.AssetDefinitionId).GreaterThan(0);
    }
  }
}
