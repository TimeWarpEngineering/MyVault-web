namespace Server.Services.AnthemGold
{
  using System.Net.Http;
  using Shared.Constants;
  public class AnthemGoldHttpClient : HttpClient
  {

    public AnthemGoldHttpClient()
    {
      BaseAddress = new System.Uri(AnthemGoldConstants.BaseUrl);
    }

  }
}
