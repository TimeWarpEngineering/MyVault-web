namespace Client.Features.Edge
{
  using BlazorState;
  using System.Collections.Generic;
  using System.Linq;

  public partial class EdgeCurrencyWalletsState : State<EdgeCurrencyWalletsState>
  {
    public EdgeCurrencyWalletsState()
    {
      EdgeCurrencyWallets = new Dictionary<string, EdgeCurrencyWallet>();
    }

    public Dictionary<string, EdgeCurrencyWallet> EdgeCurrencyWallets { get; set; }

    public EdgeCurrencyWallet SelectedEdgeCurrencyWallet
    {
      get
      {
        if (SelectedEdgeCurrencyWalletId != null &&
            EdgeCurrencyWallets.ContainsKey(SelectedEdgeCurrencyWalletId))
        {
          return EdgeCurrencyWallets[SelectedEdgeCurrencyWalletId];
        };
        if (EdgeCurrencyWallets.Count > 0)
        {
          return EdgeCurrencyWallets.First().Value;
        }
        return null;
      }
    }

    public string SelectedEdgeCurrencyWalletId { get; set; }

    public override void Initialize() => EdgeCurrencyWallets = new Dictionary<string, EdgeCurrencyWallet>();
  }
}