namespace Client.Features.Edge.Components
{
  using Client.Components;
  using Client.Features.Edge.State;
  using Microsoft.AspNetCore.Components;
  using System.Collections.Generic;
  using System.Linq;

  public class EdgeTransactionListBase : BaseComponent
  {
    [Parameter] public string CurrencyCode { get; set; }
    [Parameter] public int Granularity { get; set; }
    public List<EdgeTransaction> EdgeTransactions => EdgeCurrencyWalletsState.SelectedEdgeCurrencyWallet.EdgeTransactions.FindAll(x => x.CurrencyCode == CurrencyCode);
  }
}