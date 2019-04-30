namespace Server.Features.Conversion
{
  using System.Linq;
  using System.Threading;
  using System.Threading.Tasks;
  using AutoMapper.QueryableExtensions;
  using Microsoft.EntityFrameworkCore;
  using Server.Data;
  using Server.Entities;
  using Shared.Features.Conversion;
  using MediatR;
  using AutoMapper;
  using System.Net.Http;
  using Microsoft.AspNetCore.Components;
  using BlazorState;

  public class ConvertHandler : IRequestHandler<ConversionRequest, ConversionResponse>
  {
    public ConvertHandler(HttpClient aHttpClient) : base()
    {
      HttpClient = aHttpClient;
    }

    private HttpClient HttpClient { get; }

    public async Task<ConversionResponse> Handle(ConversionRequest aConversionRequest, CancellationToken aCancellationToken)
    {
      ConversionResponse aConversionResponse =
          await HttpClient.GetJsonAsync<ConversionResponse>
          (ConversionRequest.Route);
      return aConversionResponse;
    }
  }
}
