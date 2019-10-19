namespace Client.Features.Edge
{
  using Client.Features.Base;
  using Client.Features.Edge.Dtos;
  using System.Collections.Generic;

  public partial class EdgeCurrencyWalletsState
  {
    public class UpdateEdgeCurrencyWalletAction : BaseAction
    {
      public Dictionary<string, string> Balances { get; set; }
      public List<EdgeTransactionDto> EdgeTransactions { get; set; }
      public List<string> EnabledTokens { get; set; }
      public string FiatCurrencyCode { get; set; }
      public string Id { get; set; }
      public Dictionary<string, string> Keys { get; set; }
      public string Name { get; set; }
    }
  }
}