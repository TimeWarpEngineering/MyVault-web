namespace Server.Features.Application
{
  using AutoMapper;
  using Shared.Features.Application;
  using Server.Entities;

  public class ApplicationMappingProfile: Profile
  {
    public ApplicationMappingProfile()
    {
      CreateMap<Application, ApplicationDto>().ReverseMap();
    }
  }
}
