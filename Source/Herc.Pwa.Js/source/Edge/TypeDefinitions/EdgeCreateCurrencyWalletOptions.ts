interface EdgeCreateCurrencyWalletOptions {
  name?: string;
  fiatCurrencyCode?: string;
  // Used to tell the currency plugin what keys to create:
  //keyOptions?: EdgeCreatePrivateKeyOptions,

  // Used to copy wallet keys between accounts:
  //keys?: {}
}