namespace Server.Services.AnthemGold
{
  using System.Net.Http;
  using System.Text.Json;
  using Shared.Constants;
  public class AnthemGoldHttpClient : HttpClient
  {

    public AnthemGoldHttpClient()
    {
      BaseAddress = new System.Uri(AnthemGoldConstants.BaseUrl);
      JsonSerializerOptions = new JsonSerializerOptions
      {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
      };
      JsonSerializerOptions.Converters.Add(new DateTimeJsonConverter());
      JsonSerializerOptions.Converters.Add(new DecimalJsonConverter());
    }

    public JsonSerializerOptions JsonSerializerOptions { get; }

  }
}
