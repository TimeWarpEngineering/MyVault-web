namespace Herc.Pwa.Client.Features.Edge.Components.WalletList
{
  using Herc.Pwa.Client.Components;
  using Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet;
  using Microsoft.AspNetCore.Components;

  public class WalletItemModel : BaseComponent
  {

    public string EdgeCurrencyWalletId => EdgeCurrencyWallet.Id;

    [Parameter] protected EdgeCurrencyWallet EdgeCurrencyWallet { get; set; }

    public string Route => $"wallet/{EdgeCurrencyWallet.EncodedId}";
  }
}
