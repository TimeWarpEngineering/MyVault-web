namespace Client.Features.Edge.Components.WalletList
{
  using System.Collections.Generic;
  using System.Linq;
  using Client.Components;
  using Client.Features.Edge.EdgeCurrencyWallet;
  public class WalletListModel : BaseComponent
  {
    public List<EdgeCurrencyWallet> EdgeCurrencyWallets => EdgeCurrencyWalletsState.EdgeCurrencyWallets.Values.ToList();
  }
}
