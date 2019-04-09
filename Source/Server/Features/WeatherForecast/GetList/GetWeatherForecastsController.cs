namespace Herc.Pwa.Server.Features.WeatherForecast
{
  using System.Threading.Tasks;
  using Herc.Pwa.Server.Features.Base;
  using Herc.Pwa.Shared.Features.WeatherForecast;
  using MediatR;
  using Microsoft.AspNetCore.Mvc;

  [Route(GetWeatherForecastsRequest.Route)]
  public class WeatherForecastsController : BaseController<GetWeatherForecastsRequest, GetWeatherForecastsResponse>
  {
    public WeatherForecastsController(IMediator aMediator) : base(aMediator){ }

    public async Task<IActionResult> Get(GetWeatherForecastsRequest aRequest) => await Send(aRequest);
  }
}