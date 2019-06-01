
namespace Server.Services.CryptoCompare
{
  using Shared.Features.Conversion;
  public class CryptoCompareConstants
  {
    public const string EthCurrencyCode = CurrencyCodes.EthCurrencyCode;
    public const string CryptoCompareBaseUrl = @"https://min-api.cryptocompare.com";
    public const string SingleSymbolPriceUrl = "data/price";
    
    public const string CryptoCompareApiKey = "{96498352ca9cba1ced6bc90dedacff3c0914d050b918401d75962e8d3cfc6a71}";
    public const string UsdCurrencyCode = CurrencyCodes.UsdCurrencyCode;
    
  }
}