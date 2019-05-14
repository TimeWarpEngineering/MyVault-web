namespace Server.Services.AnthemGold
{
  using System.Net.Http;

  public class AnthemGoldHttpClient : HttpClient
  {

    public AnthemGoldHttpClient()
    {
      BaseAddress = new System.Uri(EthPriceConstants.BaseUrl);
    }

  }
}
