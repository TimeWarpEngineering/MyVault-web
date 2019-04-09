namespace Client.Features.Edge.EdgeCurrencyWallet
{
  using System.Collections.Generic;
  using Client.Features.Edge.Dtos;
  using MediatR;

  public class UpdateEdgeCurrencyWalletAction : IRequest<EdgeCurrencyWalletsState>
  {
    public Dictionary<string, string> Balances { get; set; }
    public List<string> EnabledTokens { get; set; }
    public string FiatCurrencyCode { get; set; }
    public string Id { get; set; }
    public Dictionary<string, string> Keys { get; set; }
    public string Name { get; set; }
    public List<EdgeTransactionDto> EdgeTransactions { get; set; }
  }
}