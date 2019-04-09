namespace Herc.Pwa.Shared.Features.AssetDefinition
{
  using System.Linq;
  using System.Threading;
  using System.Threading.Tasks;
  using AutoMapper;
  using AutoMapper.QueryableExtensions;
  using Herc.Pwa.Server.Data;
  using Herc.Pwa.Server.Entities;
  using MediatR;
  using Microsoft.EntityFrameworkCore;

  public class GetAssetDefinitionHandler : IRequestHandler<GetAssetDefinitionRequest, GetAssetDefinitionResponse>
  {
    public GetAssetDefinitionHandler(HercPwaDbContext aHercPwaDbContext,IConfigurationProvider aConfigurationProvider)
    {
      HercPwaDbContext = aHercPwaDbContext;
      ConfigurationProvider = aConfigurationProvider;
    }

    private HercPwaDbContext HercPwaDbContext { get; }
    private IConfigurationProvider ConfigurationProvider { get; }

    public async Task<GetAssetDefinitionResponse> Handle(
      GetAssetDefinitionRequest aGetAssetDefinitionRequest,
      CancellationToken aCancellationToken)
    {
      AssetDefinitionDto assetDefintionDto = await HercPwaDbContext
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