namespace Shared.Features.AssetDefinition
{
  using System.Threading;
  using System.Threading.Tasks;
  using AutoMapper;
  using Server.Data;
  using Server.Entities;
  using MediatR;

  public class CreateAssetDefinitionHandler : IRequestHandler<CreateAssetDefinitionRequest, CreateAssetDefinitionResponse>
  {
    public CreateAssetDefinitionHandler(AnthemGoldPwaDbContext aAnthemGoldPwaDbContext, IMapper aMapper)
    {
      AnthemGoldPwaDbContext = aAnthemGoldPwaDbContext;
      Mapper = aMapper;
    }

    private AnthemGoldPwaDbContext AnthemGoldPwaDbContext { get; }
    private IMapper Mapper { get; }

    public async Task<CreateAssetDefinitionResponse> Handle(
      CreateAssetDefinitionRequest aCreateAssetDefinitionRequest,
      CancellationToken aCancellationToken)
    {
      AssetDefinition assetDefintion = Mapper.Map<AssetDefinitionDto, AssetDefinition>(aCreateAssetDefinitionRequest.AssetDefinitionDto);
      AnthemGoldPwaDbContext.AssetDefinitions.Add(assetDefintion);
      await AnthemGoldPwaDbContext.SaveChangesAsync(aCancellationToken);
      var createAssetDefinitionResponse = new CreateAssetDefinitionResponse(aCreateAssetDefinitionRequest.Id)
      {
        AssetDefinition = Mapper.Map<AssetDefinition, AssetDefinitionDto>(assetDefintion)
      };

      return createAssetDefinitionResponse;
    }
  }
}