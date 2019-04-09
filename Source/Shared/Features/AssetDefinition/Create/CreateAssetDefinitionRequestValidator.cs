namespace Shared.Features.AssetDefinition
{
  using FluentValidation;

  public class CreateAssetDefinitionRequestValidator : AbstractValidator<CreateAssetDefinitionRequest>
  {
    public CreateAssetDefinitionRequestValidator()
    {
      RuleFor(aCreateAssetDefinitionRequest => aCreateAssetDefinitionRequest.AssetDefinitionDto)
        .SetValidator(new AssetDefinitionDtoValidator());
      RuleFor(aCreateAssetDefinitionRequest => aCreateAssetDefinitionRequest.AssetDefinitionDto)
        .NotNull();
    }
  }
}
