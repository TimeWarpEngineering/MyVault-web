namespace Client.Features.Edge.EdgeCurrencyWallet
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Net;
  using Client.Features.Edge.State;

  public class EdgeCurrencyWallet
  {

    public EdgeCurrencyWallet()
    {
      EdgeTransactions = new List<EdgeTransaction>();
      Balances = new Dictionary<string, string>();
      Keys = new Dictionary<string, string>();
      // TODO Magic strings and numbers 
      Granularity = new Dictionary<string, int> { { "ETH", 18 }, { "AHLD", 9 }, { "AGLD", 9 } };
    }

    public string ShortFiatCurrencyCode => FiatCurrencyCode.Split(':').Last();
    public Dictionary<string, string> Balances { get; set; }
    public Dictionary<string, int> Granularity { get; set; }
    public string FiatCurrencyCode { get; set; }
    public string Id { get; set; }
    public Dictionary<string, string> Keys { get; set; }
    public string Name { get; set; }
    public List<EdgeTransaction> EdgeTransactions { get; set; }
    private string _SelectedCurrencyCode;

    public string SelectedCurrencyCode
    {
      get => _SelectedCurrencyCode ?? Balances?.Keys.FirstOrDefault();
      set => _SelectedCurrencyCode = value;
    }
    public string EncodedId => WebUtility.UrlEncode(Id);
  }
}