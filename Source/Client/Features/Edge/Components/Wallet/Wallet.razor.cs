namespace Client.Features.Edge.Components.Wallet
{
  using System.Collections.Generic;
  using Client.Components;
  using Client.Features.Edge.EdgeCurrencyWallet;
  using Client.Features.Edge.State;
  using Microsoft.AspNetCore.Components;

  public class WalletModel : BaseComponent
  {
    [Parameter] protected EdgeCurrencyWallet EdgeCurrencyWallet { get; set; }

    public string Balance => EdgeCurrencyWallet.SelectedCurrencyCode != null ? EdgeCurrencyWallet?.Balances[EdgeCurrencyWallet.SelectedCurrencyCode]: null;

    public string CurrencyCode => EdgeCurrencyWallet.SelectedCurrencyCode ?? "ETH";

    public int Granularity => EdgeCurrencyWallet.Granularity[CurrencyCode];

    public void OnClickHandler(string aCurrencyCode) => EdgeCurrencyWallet.SelectedCurrencyCode = aCurrencyCode;

    
  }
}