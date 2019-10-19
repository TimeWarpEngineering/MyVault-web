namespace Server.Features.Application.Get
{
  using System.Linq;
  using System.Threading;
  using System.Threading.Tasks;
  using AutoMapper.QueryableExtensions;
  using Microsoft.EntityFrameworkCore;
  using Server.Data;
  using Server.Entities;
  using Shared.Features.Application;
  using MediatR;
  using AutoMapper;

  public class GetApplicationHandler : IRequestHandler<GetApplicationRequest, GetApplicationResponse>
  {
    public GetApplicationHandler(AnthemGoldPwaDbContext aAnthemGoldPwaDbContext, IConfigurationProvider aConfigurationProvider)
    {
      AnthemGoldPwaDbContext = aAnthemGoldPwaDbContext;
      ConfigurationProvider = aConfigurationProvider;
    }
    private AnthemGoldPwaDbContext AnthemGoldPwaDbContext { get; }
    private IConfigurationProvider ConfigurationProvider { get; }

    public async Task<GetApplicationResponse> Handle(GetApplicationRequest aGetApplicationRequest, CancellationToken aCancellationToken)
    {
      IQueryable<Application> applications = AnthemGoldPwaDbContext.Application;
      var getApplicationResponse = new GetApplicationResponse(aGetApplicationRequest.Guid);
      getApplicationResponse.Application = await applications
          .ProjectTo<ApplicationDto>(ConfigurationProvider, aCancellationToken)
          .SingleOrDefaultAsync(aCancellationToken);

      return getApplicationResponse;
    }
  }
}
