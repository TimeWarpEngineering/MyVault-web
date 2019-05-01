//namespace Server.Extentions
//{
//  using System;
//  using System.Net.Http;
//  using System.Text;
//  using System.Threading.Tasks;
//  using Newtonsoft.Json;
//  using Newtonsoft.Json.Serialization;
//  using ToQueryString.Helpers;

//  internal static class JsonContent
//  {
//    public static JsonSerializerSettings JsonSerializerSettings { get; set; } = new JsonSerializerSettings
//    {
//      ContractResolver = new CamelCasePropertyNamesContractResolver
//      {
//        NamingStrategy = new CamelCaseNamingStrategy
//        {
//          OverrideSpecifiedNames = false
//        }
//      }
//    };

//    public static async Task<T> PostAsJsonAsync<T>(this HttpClient aHttpClient, string aUrl, object aObject)
//    {
//      string objectAsJson = JsonConvert.SerializeObject(aObject, JsonSerializerSettings);
//      var stringContent = new StringContent(objectAsJson, Encoding.UTF8, "application/json");
//      HttpResponseMessage httpResponseMessage = await aHttpClient.PostAsync(aUrl, stringContent);
//      httpResponseMessage.EnsureSuccessStatusCode();
//      string responseString = await httpResponseMessage.Content.ReadAsStringAsync();
//      return JsonConvert.DeserializeObject<T>(responseString, JsonSerializerSettings);
//    }

//    public static async Task<T> GetAsJsonAsync<T>(this HttpClient aHttpClient, string aUrl, object aObject)
//    {
//      var uriBuilder = new UriBuilder(aUrl)
//      {
//        Query = UrlHelpers.ToQueryString(aObject)
//      };

//      HttpResponseMessage httpResponseMessage = await aHttpClient.GetAsync(uriBuilder.Uri);
//      httpResponseMessage.EnsureSuccessStatusCode();

//      string responseString = await httpResponseMessage.Content.ReadAsStringAsync();
//      return JsonConvert.DeserializeObject<T>(responseString, JsonSerializerSettings);
//    }
//  }
//}
