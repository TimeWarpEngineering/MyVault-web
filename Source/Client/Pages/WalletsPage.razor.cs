namespace Client.Pages
{
  using System.Collections.Generic;
  using System.Linq;
  using Client.Components;
  using Client.Features.Edge.EdgeCurrencyWallet;

  public class WalletsPageModel : BaseComponent
  {
    public const string Route = "wallets";
    public List<EdgeCurrencyWallet> EdgeCurrencyWallets => EdgeCurrencyWalletsState.EdgeCurrencyWallets.Values.ToList();

    public string TotalBalance { get; set; } = "$0.47 USD";

  }
}
