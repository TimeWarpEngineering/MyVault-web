namespace Herc.Pwa.Client.Pages
{
  using System.Net;
  using System.Threading.Tasks;
  using Herc.Pwa.Client.Components;
  using Herc.Pwa.Client.Features.Clipboard;
  using Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet;
  using Herc.Pwa.Client.Services;
  using Microsoft.AspNetCore.Components;
  using Microsoft.JSInterop;

  public class WalletReceivePageModel : BaseComponent
  {
    private EdgeCurrencyWallet EdgeCurrencyWallet => EdgeCurrencyWalletsState.EdgeCurrencyWallets[EdgeCurrencyWalletId];
    private string EdgeCurrencyWalletId => WebUtility.UrlDecode(EdgeCurrencyWalletEncodedId);
    [Parameter] protected string EdgeCurrencyWalletEncodedId { get; set; }
    [Inject] public AmountConverter AmountConverter { get; set; }
    public string ReceiveAddress => EdgeCurrencyWallet.Keys["ethereumAddress"];

    public string WalletName => EdgeCurrencyWallet.Name;

    protected async Task CopyToClipboardAsync() =>
      await JSRuntime.Current.InvokeAsync<object>(ClipboardInteropMethodNames.ClipboardInterop_WriteText, ReceiveAddress);

    public static string Route(string aEdgeCurrencyWalletEncodedId) => $"/wallet/{aEdgeCurrencyWalletEncodedId}/Receive";
  }
}