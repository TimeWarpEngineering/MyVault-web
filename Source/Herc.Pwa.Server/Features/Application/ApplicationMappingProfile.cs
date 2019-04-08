namespace Herc.Pwa.Server.Features.Application
{
  using AutoMapper;
  using Herc.Pwa.Shared.Features.Application;
  using Herc.Pwa.Server.Entities;

  public class ApplicationMappingProfile: Profile
  {
    public ApplicationMappingProfile()
    {
      CreateMap<Application, ApplicationDto>().ReverseMap();
    }
  }
}
