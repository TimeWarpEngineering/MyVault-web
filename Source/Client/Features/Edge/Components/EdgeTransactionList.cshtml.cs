namespace Herc.Pwa.Client.Features.Edge.Components
{
  using Herc.Pwa.Client.Components;
  using Herc.Pwa.Client.Features.Edge.State;
  using Microsoft.AspNetCore.Components;
  using System.Collections.Generic;
  using System.Linq;

  public class EdgeTransactionListModel : BaseComponent
  {
    [Parameter] protected string CurrencyCode { get; set; }
    public List<EdgeTransaction> EdgeTransactions => EdgeCurrencyWalletsState.SelectedEdgeCurrencyWallet.EdgeTransactions.FindAll(x => x.CurrencyCode == CurrencyCode);

  }
}