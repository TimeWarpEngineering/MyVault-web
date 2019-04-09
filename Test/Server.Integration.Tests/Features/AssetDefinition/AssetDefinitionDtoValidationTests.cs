namespace Server.Integration.Tests.Features.AssetDefinition
{
  using System.Collections.Generic;
  using System.IO;
  using System.Threading.Tasks;
  using FluentValidation.Results;
  using FluentValidation.TestHelper;
  using Shared.Features.AssetDefinition;
  using Shouldly;

  class AssetDefinitionDtoValidationTests : IntegrationTestBase
  {
    private AssetDefinitionDtoValidator AssetDefinitionDtoValidator { get; set; }
    public override Task Setup()
    {
      AssetDefinitionDtoValidator = new AssetDefinitionDtoValidator();
      return base.Setup();
    }
    public void Should_be_valid()
    {
      var assetDefinitionDto = new AssetDefinitionDto
      {
        Name = "SomeName",
        Url = "SomeUrl",
        Logo = File.ReadAllBytes("TestData/Logos/toast.jpg"),
        MetricDefinitions = new List<MetricDefinitionDto>
          {
            new MetricDefinitionDto { Name = "Metric 1", Default = "Metric 1 Default", UnitOfMeasure = "Metric 1 UofM", Description="Metric 1 Description", SampleValue="Metric 1 Sample Value", Regex= @"Metric 1 Regex" },
            new MetricDefinitionDto { Name = "Metric 2", Default = "Metric 2 Default", UnitOfMeasure = "Metric 2 UofM", Description="Metric 2 Description", SampleValue="Metric 2 Sample Value", Regex= @"Metric 2 Regex" },
            new MetricDefinitionDto { Name = "Metric 3", Default = "Metric 3 Default", UnitOfMeasure = "Metric 3 UofM", Description="Metric 3 Description", SampleValue="Metric 3 Sample Value", Regex= @"Metric 3 Regex" },
          }
      };

      //Act
      var validator = new AssetDefinitionDtoValidator();
      ValidationResult validationResult = validator.Validate(assetDefinitionDto);

      //Assert
      validationResult.IsValid.ShouldBeTrue();
    }

    // Logo
    public void Should_have_error_when_Logo_is_empty() => AssetDefinitionDtoValidator
       .ShouldHaveValidationErrorFor(aAssetDefinitionDto => aAssetDefinitionDto.Logo, new byte[0]);

    public void Should_have_error_when_Logo_is_null() => AssetDefinitionDtoValidator
       .ShouldHaveValidationErrorFor(aAssetDefinitionDto => aAssetDefinitionDto.Logo, null as byte[]);

    // MetricDefinitions
    public void Should_have_error_when_MetricsDefintions_is_null() => AssetDefinitionDtoValidator
       .ShouldHaveValidationErrorFor(aAssetDefinitionDto => aAssetDefinitionDto.MetricDefinitions, null as List<MetricDefinitionDto>);
    public void Should_have_child_validator_for_MetricsDefintions() => AssetDefinitionDtoValidator
       .ShouldHaveChildValidator(aAssetDefinitionDto => aAssetDefinitionDto.MetricDefinitions, typeof(MetricDefinitionDtoValidator));

    public void Should_have_error_when_MetricsDefintions_Count_greater_than_8() => AssetDefinitionDtoValidator
      .ShouldHaveValidationErrorFor(aAssetDefinitionDto => aAssetDefinitionDto.MetricDefinitions,
      new List<MetricDefinitionDto>
          {
            new MetricDefinitionDto { Name = "Metric 1", Default = "0.9999", UnitOfMeasure = "Fineness", Description="A Bar of Gold", SampleValue="0.9999", Regex= @"^0([.,])\d+" },
            new MetricDefinitionDto { Name = "Metric 2", Description="Metric Description", SampleValue="123456", UnitOfMeasure="Identifier" },
            new MetricDefinitionDto { Name = "Metric 3", Description="Metric Description", SampleValue="123456", UnitOfMeasure="Identifier" },
            new MetricDefinitionDto { Name = "Metric 4", Description="Metric Description", SampleValue="123456", UnitOfMeasure="Identifier" },
            new MetricDefinitionDto { Name = "Metric 5", Description="Metric Description", SampleValue="123456", UnitOfMeasure="Identifier" },
            new MetricDefinitionDto { Name = "Metric 6", Description="Metric Description", SampleValue="123456", UnitOfMeasure="Identifier" },
            new MetricDefinitionDto { Name = "Metric 7", Description="Metric Description", SampleValue="123456", UnitOfMeasure="Identifier" },
            new MetricDefinitionDto { Name = "Metric 8", Description="Metric Description", SampleValue="123456", UnitOfMeasure="Identifier" },
            new MetricDefinitionDto { Name = "Metric 9", Description="Metric Description", SampleValue="123456", UnitOfMeasure="Identifier" }
          }
      );

    public void Should_have_error_when_MetricsDefintions_Count_less_than_3() => AssetDefinitionDtoValidator
      .ShouldHaveValidationErrorFor(aAssetDefinitionDto => aAssetDefinitionDto.MetricDefinitions,
      new List<MetricDefinitionDto>
          {
            new MetricDefinitionDto { Name = "Metric 1", Default = "0.9999", UnitOfMeasure = "Fineness", Description="A Bar of Gold", SampleValue="0.9999", Regex= @"^0([.,])\d+" },
            new MetricDefinitionDto { Name = "Metric 2", Description="Metric Description", SampleValue="123456", UnitOfMeasure="Identifier" },
          }
      );

    // Name
    public void Should_have_error_when_Name_is_empty() => AssetDefinitionDtoValidator
        .ShouldHaveValidationErrorFor(aAssetDefinitionDto => aAssetDefinitionDto.Name, string.Empty);

    public void Should_have_error_when_Name_is_null() => AssetDefinitionDtoValidator
        .ShouldHaveValidationErrorFor(aAssetDefinitionDto => aAssetDefinitionDto.Name, null as string);

    // Url
    public void Should_have_error_when_Url_is_empty() => AssetDefinitionDtoValidator
       .ShouldHaveValidationErrorFor(aAssetDefinitionDto => aAssetDefinitionDto.Url, string.Empty);

    public void Should_have_error_when_Url_is_null() => AssetDefinitionDtoValidator
   .ShouldHaveValidationErrorFor(aAssetDefinitionDto => aAssetDefinitionDto.Url, null as string);
  }
}
