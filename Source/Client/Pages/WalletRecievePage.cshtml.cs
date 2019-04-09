namespace Client.Pages
{
  using System.Net;
  using System.Threading.Tasks;
  using Client.Components;
  using Client.Features.Clipboard;
  using Client.Features.Edge.EdgeCurrencyWallet;
  using Client.Services;
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