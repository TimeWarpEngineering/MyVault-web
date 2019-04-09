namespace Client.Features.Edge.EdgeCurrencyWallet
{
  using System.Collections.Generic;
  using Client.Features.Edge.Dtos;

  public class EdgeCurrencyWalletDto
  {
    public string FiatCurrencyCode { get; set; }
    public string Id { get; set; }
    public Dictionary<string, string> Keys { get; set; }
    public Dictionary<string, string> Balances { get; set; }
    public List<EdgeTransactionDto> EdgeTransactions { get; set; }
  }
}