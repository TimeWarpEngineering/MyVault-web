namespace Herc.Pwa.Server.Features.Application
{
  using AutoMapper;
  using Herc.Pwa.Server.Entities;
  using Herc.Pwa.Shared.Features.AssetDefinition;

  public class AssetDefinitionMappingProfile: Profile
  {
    public AssetDefinitionMappingProfile()
    {
      CreateMap<AssetDefinition, AssetDefinitionDto>().ReverseMap();
      CreateMap<MetricDefinition, MetricDefinitionDto>().ReverseMap();
    }
  }
}
