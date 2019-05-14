namespace Server.Services.EthPrice
{
  using System.Net.Http;

  public class EthPriceHttpClient : HttpClient
  {

    public EthPriceHttpClient()
    {
      BaseAddress = new System.Uri(EthPriceConstants.EthPriceUrl);
    }

  }
}
