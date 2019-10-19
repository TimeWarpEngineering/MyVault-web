namespace Client.Features.Edge
{
  using Client.Features.Edge.State;
  using System.Collections.Generic;
  using System.Linq;
  using System.Net;

  public class EdgeCurrencyWallet
  {
    private string _SelectedCurrencyCode;

    public EdgeCurrencyWallet()
    {
      EdgeTransactions = new List<EdgeTransaction>();
      Balances = new Dictionary<string, string>();
      Keys = new Dictionary<string, string>();
      // TODO Magic strings and numbers
      Granularity = new Dictionary<string, int> { { "ETH", 18 }, { "AHLD", 9 }, { "AGLD", 9 } };
    }

    public Dictionary<string, string> Balances { get; set; }
    public List<EdgeTransaction> EdgeTransactions { get; set; }
    public string EncodedId => WebUtility.UrlEncode(Id);
    public string FiatCurrencyCode { get; set; }
    public Dictionary<string, int> Granularity { get; set; }
    public string Id { get; set; }
    public Dictionary<string, string> Keys { get; set; }
    public string Name { get; set; }

    public string SelectedCurrencyCode
    {
      get => _SelectedCurrencyCode ?? Balances?.Keys.FirstOrDefault();
      set => _SelectedCurrencyCode = value;
    }

    public string ShortFiatCurrencyCode => FiatCurrencyCode.Split(':').Last();
  }
}