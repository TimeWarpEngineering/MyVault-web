﻿namespace Server.Features.Application.Get
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
