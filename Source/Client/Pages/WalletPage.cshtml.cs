namespace Client.Pages
{
  using Client.Components;
  using Client.Features.Edge.EdgeCurrencyWallet;

  public class WalletPageModel : BaseComponent
  {
    public const string Route = "/wallet";
    public EdgeCurrencyWallet EdgeCurrencyWallet => EdgeCurrencyWalletsState.SelectedEdgeCurrencyWallet;
  }
}