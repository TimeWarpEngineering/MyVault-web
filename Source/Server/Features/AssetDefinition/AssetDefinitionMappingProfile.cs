namespace Server.Features.Application
{
  using AutoMapper;
  using Server.Entities;
  using Shared.Features.AssetDefinition;

  public class AssetDefinitionMappingProfile: Profile
  {
    public AssetDefinitionMappingProfile()
    {
      CreateMap<AssetDefinition, AssetDefinitionDto>().ReverseMap();
      CreateMap<MetricDefinition, MetricDefinitionDto>().ReverseMap();
    }
  }
}
