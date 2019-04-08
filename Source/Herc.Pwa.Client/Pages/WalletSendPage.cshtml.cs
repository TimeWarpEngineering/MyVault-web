namespace Herc.Pwa.Client.Pages
{
  using Herc.Pwa.Client.Components;
  using Microsoft.AspNetCore.Components;

  public class WalletSendPageModel : BaseComponent
  {
    [Parameter] protected string EdgeCurrencyWalletEncodedId { get; set; }
    public static string Route(string aEdgeCurrencyWalletEncodedId) => $"/wallet/{aEdgeCurrencyWalletEncodedId}/Send";
  }
}