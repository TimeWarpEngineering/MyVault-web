namespace Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet
{
  using System.Collections.Generic;
  using System.Linq;

  public partial class EdgeCurrencyWalletsState
  {
    public Dictionary<string, EdgeCurrencyWallet> EdgeCurrencyWallets { get; set; }

    public string SelectedEdgeCurrencyWalletId { get; set; }

    public EdgeCurrencyWallet SelectedEdgeCurrencyWallet {
      get {
        if ( SelectedEdgeCurrencyWalletId != null &&
            EdgeCurrencyWallets.ContainsKey(SelectedEdgeCurrencyWalletId))
        {
          return EdgeCurrencyWallets[SelectedEdgeCurrencyWalletId];
        };
        if(EdgeCurrencyWallets.Count > 0)
        {
          return EdgeCurrencyWallets.First().Value;
        }
        return null;
      }
    }
    
  }

}