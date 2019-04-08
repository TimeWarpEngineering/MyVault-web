namespace Herc.Pwa.Server.Features.Application.Get
{
  using System.Linq;
  using System.Threading;
  using System.Threading.Tasks;
  using AutoMapper.QueryableExtensions;
  using Microsoft.EntityFrameworkCore;
  using Herc.Pwa.Server.Data;
  using Herc.Pwa.Server.Entities;
  using Herc.Pwa.Shared.Features.Application;
  using MediatR;
  using AutoMapper;

  public class GetApplicationHandler : IRequestHandler<GetApplicationRequest, GetApplicationResponse>
  {
    public GetApplicationHandler(HercPwaDbContext aHercPwaDbContext, IConfigurationProvider aConfigurationProvider)
    {
      HercPwaDbContext = aHercPwaDbContext;
      ConfigurationProvider = aConfigurationProvider;
    }
    private HercPwaDbContext HercPwaDbContext { get; }
    private IConfigurationProvider ConfigurationProvider { get; }

    public async Task<GetApplicationResponse> Handle(GetApplicationRequest aGetApplicationRequest, CancellationToken aCancellationToken)
    {
      IQueryable<Application> applications = HercPwaDbContext.Application;
      var getApplicationResponse = new GetApplicationResponse(aGetApplicationRequest.Id);
      getApplicationResponse.Application = await applications
          .ProjectTo<ApplicationDto>(ConfigurationProvider, aCancellationToken)
          .SingleOrDefaultAsync(aCancellationToken);

      return getApplicationResponse;
    }
  }
}
