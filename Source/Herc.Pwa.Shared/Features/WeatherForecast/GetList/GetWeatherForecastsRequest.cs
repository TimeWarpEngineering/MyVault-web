namespace Herc.Pwa.Shared.Features.WeatherForecast
{
  using Herc.Pwa.Shared.Features.Base;
  using MediatR;

  public class GetWeatherForecastsRequest : BaseRequest, IRequest<GetWeatherForecastsResponse>
  {
    public const string Route = "api/weatherForecast";
  }
}