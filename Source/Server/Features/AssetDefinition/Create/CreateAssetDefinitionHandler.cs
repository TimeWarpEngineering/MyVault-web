namespace Herc.Pwa.Shared.Features.AssetDefinition
{
  using System.Threading;
  using System.Threading.Tasks;
  using AutoMapper;
  using Herc.Pwa.Server.Data;
  using Herc.Pwa.Server.Entities;
  using MediatR;

  public class CreateAssetDefinitionHandler : IRequestHandler<CreateAssetDefinitionRequest, CreateAssetDefinitionResponse>
  {
    public CreateAssetDefinitionHandler(HercPwaDbContext aHercPwaDbContext, IMapper aMapper)
    {
      HercPwaDbContext = aHercPwaDbContext;
      Mapper = aMapper;
    }

    private HercPwaDbContext HercPwaDbContext { get; }
    private IMapper Mapper { get; }

    public async Task<CreateAssetDefinitionResponse> Handle(
      CreateAssetDefinitionRequest aCreateAssetDefinitionRequest,
      CancellationToken aCancellationToken)
    {
      AssetDefinition assetDefintion = Mapper.Map<AssetDefinitionDto, AssetDefinition>(aCreateAssetDefinitionRequest.AssetDefinitionDto);
      HercPwaDbContext.AssetDefinitions.Add(assetDefintion);
      await HercPwaDbContext.SaveChangesAsync(aCancellationToken);
      var createAssetDefinitionResponse = new CreateAssetDefinitionResponse(aCreateAssetDefinitionRequest.Id)
      {
        AssetDefinition = Mapper.Map<AssetDefinition, AssetDefinitionDto>(assetDefintion)
      };

      return createAssetDefinitionResponse;
    }
  }
}