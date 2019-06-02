namespace Server.Integration.Tests.Features.AssetDefinition.Get
{
  using System.Threading.Tasks;
  using Server.Entities;
  using Shared.Features.AssetDefinition;
  using Shouldly;

  class GetAssetDefinitionTests : IntegrationTestBase
  {
    private const string AssetDefinitionName = "AnthemGold";
    private const string AssetDefinitionUrl = "https://anthembunker.com";

    public async Task Should_get_AssetDefinition()
    {
      //Arrange
      // Build the AssetDefinition
      var assetDefinition = new AssetDefinition()
      {
        Name = AssetDefinitionName,
        Url = AssetDefinitionUrl,
      };

      var metricDefinitions = new MetricDefinition[]
      {
        new MetricDefinition { Name = "Assay", Default = "0.9999", UnitOfMeasure = "Fineness", Description="A Bar of Gold", SampleValue="0.9999", Regex= @"^0([.,])\d+" },
        new MetricDefinition { Name = "Bar Serial #", Description="The serial number of the bar of gold", SampleValue="123456", UnitOfMeasure="Identifier" }
      };
      assetDefinition.MetricDefinitions = metricDefinitions;

      await InsertAsync(assetDefinition);

      var getAssetDefinitionRequest = new GetAssetDefinitionRequest
      {
        AssetDefinitionId = assetDefinition.AssetDefinitionId
      };

      //Act
      GetAssetDefinitionResponse getAssetDefinitionResponse = await SendAsync(getAssetDefinitionRequest);

      //Assert
      getAssetDefinitionResponse.AssetDefinition.ShouldNotBeNull();
      AssetDefinitionDto assetDefinitionDto = getAssetDefinitionResponse.AssetDefinition;
      assetDefinitionDto.Name.ShouldBe(AssetDefinitionName);
      assetDefinitionDto.Url.ShouldBe(AssetDefinitionUrl);
      assetDefinitionDto.MetricDefinitions.Count.ShouldBe(2);
      assetDefinitionDto.MetricDefinitions[0].Description.ShouldBe(assetDefinition.MetricDefinitions[0].Description);
    }

    public async Task Should_NOT_get_AssetDefinition()
    {
      //Arrange
      // Build the AssetDefinition
      var assetDefinition = new AssetDefinition()
      {
        Name = AssetDefinitionName,
        Url = AssetDefinitionUrl,
      };

      var metricDefinitions = new MetricDefinition[]
      {
        new MetricDefinition { Name = "Assay", Default = "0.9999", UnitOfMeasure = "Fineness", Description="A Bar of Gold", SampleValue="0.9999", Regex= @"^0([.,])\d+" },
        new MetricDefinition { Name = "Bar Serial #", Description="The serial number of the bar of gold", SampleValue="123456", UnitOfMeasure="Identifier" }
      };
      assetDefinition.MetricDefinitions = metricDefinitions;

      await InsertAsync(assetDefinition);

      var getAssetDefinitionRequest = new GetAssetDefinitionRequest
      {
        AssetDefinitionId = assetDefinition.AssetDefinitionId+1
      };

      //Act
      GetAssetDefinitionResponse getAssetDefinitionResponse = await SendAsync(getAssetDefinitionRequest);

      //Assert
      getAssetDefinitionResponse.AssetDefinition.ShouldBeNull();
     
    }
  }
}
