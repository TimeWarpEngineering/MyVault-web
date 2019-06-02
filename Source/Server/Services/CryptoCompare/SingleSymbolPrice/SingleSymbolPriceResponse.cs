namespace Server.Services.CryptoCompare.SingleSymbolPrice
{
  using System.Collections.Generic;

  public class SingleSymbolPriceResponse
  {
    public Dictionary<string, decimal> Prices { get; set; } 
  }
}
