namespace Herc.Pwa.Shared.Features.AssetDefinition
{
  using FluentValidation;
  using System.Linq;

  public class AssetDefinitionDtoValidator : AbstractValidator<AssetDefinitionDto>
  {
    public AssetDefinitionDtoValidator()
    {
      RuleFor(aAssetDefinitionDto => aAssetDefinitionDto.Name)
        .NotEmpty();

      // TODO: check for valid URL maybe even check if link returns although that will be slower.
      RuleFor(aAssetDefinitionDto => aAssetDefinitionDto.Url)
        .NotEmpty();

      // TODO: Logo validation needs to be more than this.
      // Should validate it actually is an image?
      // Should limit the size?
      // Actually the Controller may need to do more work if we use IFormFile
      // See Notes Cramer-2018-08-11.md
      RuleFor(aAssetDefinitionDto => aAssetDefinitionDto.Logo)
        .NotEmpty();

      RuleFor(aAssetDefinitionDto => aAssetDefinitionDto.MetricDefinitions)
        .NotNull();

      RuleFor(aAssetDefinitionDto => aAssetDefinitionDto.MetricDefinitions)
        .Must(aMetricDefinitions => aMetricDefinitions.Count >= 3 && aMetricDefinitions.Count <= 8)
        .WithMessage("Metric Definitions requires a minimum of 3 and maximum of 8")
        .When(aAssetDefinitionDto => aAssetDefinitionDto.MetricDefinitions != null);

      RuleForEach(aAssetDefinitionDto => aAssetDefinitionDto.MetricDefinitions)
        .SetValidator(new MetricDefinitionDtoValidator());
    }
  }
}
