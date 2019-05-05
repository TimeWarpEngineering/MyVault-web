//namespace Server.Integration.Tests.Features.AssetDefinition.Create
//{
//  using System.Threading.Tasks;
//  using FluentValidation.TestHelper;
//  using Shared.Features.AssetDefinition;

//  class CreateAssetDefinitionRequestValidationTests : IntegrationTestBase
//  {

//    private CreateAssetDefinitionRequestValidator CreateAssetDefinitionRequestValidator { get; set; }

//    public override Task Setup()
//    {
//      CreateAssetDefinitionRequestValidator = new CreateAssetDefinitionRequestValidator();
//      return base.Setup();
//    }

//    //public void Should_have_child_validator_for_AssetDefintionDto() => CreateAssetDefinitionRequestValidator
//    //  .ShouldHaveChildValidator
//    //    (aCreateAssetDefinitionRequestValidator =>
//    //      aCreateAssetDefinitionRequestValidator.AssetDefinitionDto, typeof(AssetDefinitionDtoValidator));

//    public void Should_have_error_when_AssetDefinitionDto_is_null() => CreateAssetDefinitionRequestValidator
//      .ShouldHaveValidationErrorFor
//        (aCreateAssetDefinitionRequestValidator =>
//          aCreateAssetDefinitionRequestValidator.AssetDefinitionDto, null as AssetDefinitionDto);
//  }
//}
