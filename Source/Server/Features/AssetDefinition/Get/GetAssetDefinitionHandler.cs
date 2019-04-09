namespace Shared.Features.AssetDefinition
{
  using System.Linq;
  using System.Threading;
  using System.Threading.Tasks;
  using AutoMapper;
  using AutoMapper.QueryableExtensions;
  using Server.Data;
  using Server.Entities;
  using MediatR;
  using Microsoft.EntityFrameworkCore;

  public class GetAssetDefinitionHandler : IRequestHandler<GetAssetDefinitionRequest, GetAssetDefinitionResponse>
  {
    public GetAssetDefinitionHandler(AnthemGoldPwaDbContext aAnthemGoldPwaDbContext,IConfigurationProvider aConfigurationProvider)
    {
      AnthemGoldPwaDbContext = aAnthemGoldPwaDbContext;
      ConfigurationProvider = aConfigurationProvider;
    }

    private AnthemGoldPwaDbContext AnthemGoldPwaDbContext { get; }
    private IConfigurationProvider ConfigurationProvider { get; }

    public async Task<GetAssetDefinitionResponse> Handle(
      GetAssetDefinitionRequest aGetAssetDefinitionRequest,
      CancellationToken aCancellationToken)
    {
      AssetDefinitionDto assetDefintionDto = await AnthemGoldPwaDbContext
        .AssetDefinitions
        .Where(aAssetDefinition => aAssetDefinition.AssetDefinitionId == aGetAssetDefinitionRequest.AssetDefinitionId)
        .ProjectTo<AssetDefinitionDto>(ConfigurationProvider)
        .SingleOrDefaultAsync(aCancellationToken);

      var getAssetDefinitionResponse = new GetAssetDefinitionResponse(aGetAssetDefinitionRequest.Id)
      {
        AssetDefinition = assetDefintionDto
      };

      return getAssetDefinitionResponse;
    }
  }
}