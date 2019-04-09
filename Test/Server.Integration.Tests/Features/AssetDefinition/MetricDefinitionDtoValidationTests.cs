namespace Server.Integration.Tests.Features.AssetDefinition
{
  using System.Collections.Generic;
  using System.IO;
  using System.Threading.Tasks;
  using FluentValidation.Results;
  using FluentValidation.TestHelper;
  using Shared.Features.AssetDefinition;
  using Shouldly;

  class MetricDefinitionDtoValidationTests : IntegrationTestBase
  {
    private MetricDefinitionDtoValidator MetricDefinitionDtoValidator { get; set; }
    public override Task Setup()
    {
      MetricDefinitionDtoValidator = new MetricDefinitionDtoValidator();
      return base.Setup();
    }
    public void Should_be_valid()
    {
      var metricDefinitionDto = new MetricDefinitionDto
      {
        Name = "Metric 1",
        Default = "Metric 1 Default",
        UnitOfMeasure = "Metric 1 UofM",
        Description ="Metric 1 Description",
        SampleValue ="Metric 1 Sample Value",
        Regex = @"Metric 1 Regex"
      };

      //Act

      ValidationResult validationResult = MetricDefinitionDtoValidator.Validate(metricDefinitionDto);

      //Assert
      validationResult.IsValid.ShouldBeTrue();
    }

    // Description
    public void Should_have_error_when_Description_is_null() => MetricDefinitionDtoValidator
       .ShouldHaveValidationErrorFor(aAssetDefinitionDto => aAssetDefinitionDto.Description, null as string);

    public void Should_have_error_when_Description_is_empty() => MetricDefinitionDtoValidator
       .ShouldHaveValidationErrorFor(aAssetDefinitionDto => aAssetDefinitionDto.Description, string.Empty);

    // Name
    public void Should_have_error_when_Name_is_empty() => MetricDefinitionDtoValidator
        .ShouldHaveValidationErrorFor(aMetricDefinitionDto => aMetricDefinitionDto.Name, string.Empty);

    public void Should_have_error_when_Name_is_null() => MetricDefinitionDtoValidator
        .ShouldHaveValidationErrorFor(aMetricDefinitionDto => aMetricDefinitionDto.Name, null as string);

    // SampleValue
    public void Should_have_error_when_SampleValue_is_empty() => MetricDefinitionDtoValidator
       .ShouldHaveValidationErrorFor(aAssetDefinitionDto => aAssetDefinitionDto.SampleValue, string.Empty);

    public void Should_have_error_when_SampleValue_is_null() => MetricDefinitionDtoValidator
       .ShouldHaveValidationErrorFor(aAssetDefinitionDto => aAssetDefinitionDto.SampleValue, null as string);

    // UnitOfMeasure
    public void Should_have_error_when_UnitOfMeasure_is_empty() => MetricDefinitionDtoValidator
       .ShouldHaveValidationErrorFor(aAssetDefinitionDto => aAssetDefinitionDto.UnitOfMeasure, string.Empty);

    public void Should_have_error_when_UnitOfMeasure_is_null() => MetricDefinitionDtoValidator
       .ShouldHaveValidationErrorFor(aAssetDefinitionDto => aAssetDefinitionDto.UnitOfMeasure, null as string);

    // Regex has no constraints
  }
}
