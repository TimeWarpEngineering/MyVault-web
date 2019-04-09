namespace Herc.Pwa.Client.Features.Edge.Components.Wallet
{
  using System.Collections.Generic;
  using Herc.Pwa.Client.Components;
  using Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet;
  using Herc.Pwa.Client.Features.Edge.State;
  using Microsoft.AspNetCore.Components;

  public class WalletModel : BaseComponent
  {
    [Parameter] protected EdgeCurrencyWallet EdgeCurrencyWallet { get; set; }

    public string Balance => EdgeCurrencyWallet.SelectedCurrencyCode != null ? EdgeCurrencyWallet?.Balances[EdgeCurrencyWallet.SelectedCurrencyCode]: null;

    public string CurrencyCode => EdgeCurrencyWallet.SelectedCurrencyCode;

    public void OnClickHandler(string aCurrencyCode) => EdgeCurrencyWallet.SelectedCurrencyCode = aCurrencyCode;

    
  }
}