namespace Server.Services.CryptoCompare
{
  using Shared.Constants;
  using System.Net.Http;

  public class CryptoCompareHttpClient : HttpClient
  {

    public CryptoCompareHttpClient()
    {
      BaseAddress = new System.Uri(CryptoCompareConstants.CryptoCompareBaseUrl);
      DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Apikey", CryptoCompareConstants.CryptoCompareApiKey );
      
    }

  }
}
