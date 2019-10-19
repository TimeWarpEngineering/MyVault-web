namespace Client.Pages
{
  using Client.Components;
  using Client.Features.Edge;

  public class WalletPageBase : BaseComponent
  {
    public const string Route = "/wallet";
    public EdgeCurrencyWallet EdgeCurrencyWallet => EdgeCurrencyWalletsState.SelectedEdgeCurrencyWallet;
  }
}