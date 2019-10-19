namespace Client.Features.Edge.Components.WalletList
{
  using Client.Components;
  using Client.Features.Edge;
  using Microsoft.AspNetCore.Components;

  public class WalletItemBase : BaseComponent
  {

    public string EdgeCurrencyWalletId => EdgeCurrencyWallet.Id;

    [Parameter] public EdgeCurrencyWallet EdgeCurrencyWallet { get; set; }

    public string Route => $"wallet/{EdgeCurrencyWallet.EncodedId}";
  }
}
