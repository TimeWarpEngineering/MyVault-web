namespace Client.Features.Edge.Components.WalletList
{
  using System.Collections.Generic;
  using System.Linq;
  using Client.Components;
  using Client.Features.Edge;
  public class WalletListBase : BaseComponent
  {
    public List<EdgeCurrencyWallet> EdgeCurrencyWallets => EdgeCurrencyWalletsState.EdgeCurrencyWallets.Values.ToList();
  }
}
