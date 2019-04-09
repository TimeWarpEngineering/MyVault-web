namespace Server.Features.WeatherForecast
{
  using System.Threading.Tasks;
  using Server.Features.Base;
  using Shared.Features.WeatherForecast;
  using MediatR;
  using Microsoft.AspNetCore.Mvc;

  [Route(GetWeatherForecastsRequest.Route)]
  public class WeatherForecastsController : BaseController<GetWeatherForecastsRequest, GetWeatherForecastsResponse>
  {
    public WeatherForecastsController(IMediator aMediator) : base(aMediator){ }

    public async Task<IActionResult> Get(GetWeatherForecastsRequest aRequest) => await Send(aRequest);
  }
}