namespace Server.Integration.Tests.Features.AssetDefinition.Create
{
  using System.Collections.Generic;
  using System.Threading.Tasks;
  using Shared.Features.AssetDefinition;
  using Shouldly;

  class CreateAssetDefinitionTests : IntegrationTestBase
  {
    private const string AssetDefinitionName = "AnthemGold";
    private const string AssetDefinitionUrl = "https://anthembunker.com";

    public async Task Should_create_new_AssetDefinition()
    {
      //Arrange
      var createAssetDefinitionRequest = new CreateAssetDefinitionRequest()
      {
        AssetDefinitionDto = new AssetDefinitionDto
        {
          Name = AssetDefinitionName,
          Url = AssetDefinitionUrl,
          MetricDefinitions = new List<MetricDefinitionDto>
            {
              new MetricDefinitionDto { Name = "Assay", Default = "0.9999", UnitOfMeasure = "Fineness", Description="A Bar of Gold", SampleValue="0.9999", Regex= @"^0([.,])\d+" },
              new MetricDefinitionDto { Name = "Bar Serial #", Description="The serial number of the bar of gold", SampleValue="123456", UnitOfMeasure="Identifier" }
            }
        }
      };

      //Act
      CreateAssetDefinitionResponse createAssetDefinitionResponse = await SendAsync(createAssetDefinitionRequest);

      //Assert
      createAssetDefinitionResponse.AssetDefinition.ShouldNotBeNull();
      AssetDefinitionDto assetDefinition = createAssetDefinitionResponse.AssetDefinition;
      assetDefinition.Name.ShouldBe(AssetDefinitionName);
      assetDefinition.Url.ShouldBe(AssetDefinitionUrl);
      assetDefinition.MetricDefinitions.Count.ShouldBe(2);
    }
  }
}
