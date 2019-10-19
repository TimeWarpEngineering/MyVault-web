namespace Client.Pages
{
  using Client.Components;
  using Microsoft.AspNetCore.Components;

  public class WalletSendPageBase : BaseComponent
  {
    [Parameter] public string EdgeCurrencyWalletId { get; set; }
    public static string Route(string aEdgeCurrencyWalletId) => $"/wallet/{aEdgeCurrencyWalletId}/Send";
  }
}