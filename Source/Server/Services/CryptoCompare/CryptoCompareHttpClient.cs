namespace Server.Services.CryptoCompare
{
  using System.Net.Http;
  using static CryptoCompareConstants;

  public class CryptoCompareHttpClient : HttpClient
  {

    public CryptoCompareHttpClient()
    {
      BaseAddress = new System.Uri(CryptoCompareConstants.CryptoCompareBaseUrl);
      DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Apikey",  CryptoCompareApiKey );
      
    }

  }
}
