namespace Client.Features.Edge.Components.WalletList
{
  using Client.Components;
  using Client.Features.Edge.EdgeCurrencyWallet;
  using Microsoft.AspNetCore.Components;

  public class WalletItemModel : BaseComponent
  {

    public string EdgeCurrencyWalletId => EdgeCurrencyWallet.Id;

    [Parameter] protected EdgeCurrencyWallet EdgeCurrencyWallet { get; set; }

    public string Route => $"wallet/{EdgeCurrencyWallet.EncodedId}";
  }
}
