namespace Server.Integration.Tests.Features.AssetDefinition.Get
{
  using System.Threading.Tasks;
  using FluentValidation.TestHelper;
  using Shared.Features.AssetDefinition;

  class GetAssetDefinitionRequestValidationTests : IntegrationTestBase
  {
    private GetAssetDefinitionRequestValidator GetAssetDefinitionRequestValidator { get; set; }

    public override Task Setup()
    {
      GetAssetDefinitionRequestValidator = new GetAssetDefinitionRequestValidator();
      return base.Setup();
    }

    public void Should_NOT_have_error_when_AssetDefinitionId_is_positive_1() => GetAssetDefinitionRequestValidator
      .ShouldNotHaveValidationErrorFor
        (aCreateAssetDefinitionRequestValidator =>
          aCreateAssetDefinitionRequestValidator.AssetDefinitionId, 1);

    public void Should_have_error_when_AssetDefinitionId_is_negative_1() => GetAssetDefinitionRequestValidator
      .ShouldHaveValidationErrorFor
        (aCreateAssetDefinitionRequestValidator =>
          aCreateAssetDefinitionRequestValidator.AssetDefinitionId, -1);

    public void Should_have_error_when_AssetDefinitionId_is_zero() => GetAssetDefinitionRequestValidator
      .ShouldHaveValidationErrorFor
        (aCreateAssetDefinitionRequestValidator =>
          aCreateAssetDefinitionRequestValidator.AssetDefinitionId, 0);
  }
}
