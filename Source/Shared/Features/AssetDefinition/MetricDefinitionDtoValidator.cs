namespace Shared.Features.AssetDefinition
{
  using FluentValidation;

  public class MetricDefinitionDtoValidator : AbstractValidator<MetricDefinitionDto>
  {
    public MetricDefinitionDtoValidator()
    {
      // Default value not required.

      RuleFor(aMetricDefinitionDto => aMetricDefinitionDto.Description)
        .NotEmpty();

      RuleFor(aMetricDefinitionDto => aMetricDefinitionDto.Name)
        .NotEmpty();

      RuleFor(aMetricDefinitionDto => aMetricDefinitionDto.SampleValue)
        .NotEmpty();

      // This could be checked aginst ISO list if one exists
      RuleFor(aMetricDefinitionDto => aMetricDefinitionDto.UnitOfMeasure)
        .NotEmpty();


      // Regex expression.. we would need to validate it is a valid Regex.
      // Should we request type (int string etc)...
    }
  }
}
