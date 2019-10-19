namespace Client.Pages
{
  using System.Net;
  using System.Threading.Tasks;
  using Client.Components;
  using Client.Features.Clipboard;
  using Client.Features.Edge;
  using Client.Services;
  using Microsoft.AspNetCore.Components;
  using Microsoft.JSInterop;

  public class WalletReceivePageBase : BaseComponent
      {

    private EdgeCurrencyWallet EdgeCurrencyWallet => EdgeCurrencyWalletsState.EdgeCurrencyWallets[EdgeCurrencyWalletId];
    [Parameter] public string EdgeCurrencyWalletId { get; set; }
    [Inject] public AmountConverter AmountConverter { get; set; }
   [Inject] IJSRuntime JSRuntime { get; set; }
    public string ReceiveAddress => EdgeCurrencyWallet.Keys["ethereumAddress"];

    public string WalletName => EdgeCurrencyWallet.Name;

    protected async Task CopyToClipboardAsync() =>
      await JSRuntime.InvokeAsync<object>(ClipboardInteropMethodNames.ClipboardInterop_WriteText, ReceiveAddress);

    public static string Route(string aEdgeCurrencyWalletId) => $"/wallet/{aEdgeCurrencyWalletId}/Receive";
  }
}