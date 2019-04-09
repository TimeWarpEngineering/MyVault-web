import { EdgeCurrencyWallet } from "./EdgeCurrencyWallet";
import { EdgeCurrencyConfig } from "./EdgeCurrencyConfig";
import { Subscriber } from "./Subscriber";

export type EdgeAccountEvents = {}

export interface EdgeAccount {
  readonly on: Subscriber<EdgeAccountEvents>,
  readonly watch: Subscriber<EdgeAccount>,

  // Data store:
  readonly id: string,
  readonly keys: any,
  readonly type: string,
  //readonly folder: DiskletFolder,
  //readonly localFolder: DiskletFolder,
  //sync(): Promise<mixed>,

  // Basic login information:
  readonly appId: string,
  readonly loggedIn: boolean,
  readonly loginKey: string,
  readonly recoveryKey: string | void, // For email backup
  readonly username: string,

  // Special-purpose API's:
  readonly currencyConfig: { [pluginName: string]: EdgeCurrencyConfig },
  //readonly rateCache: EdgeRateCache,
  //readonly swapConfig: { [pluginName: string]: EdgeSwapConfig },
  //readonly dataStore: EdgeDataStore,

  // What login method was used?
  readonly edgeLogin: boolean,
  readonly keyLogin: boolean,
  readonly newAccount: boolean,
  readonly passwordLogin: boolean,
  readonly pinLogin: boolean,
  readonly recoveryLogin: boolean,

  // Change or create credentials:
  changePassword(password: string): Promise<any>,
  changePin(opts: {
    pin?: string, // We keep the existing PIN if unspecified
    enableLogin?: boolean // We default to true if unspecified
  }): Promise<string>,
  changeRecovery(
    questions: Array<string>,
    answers: Array<string>
  ): Promise<string>,

  // Verify existing credentials:
  checkPassword(password: string): Promise<boolean>,
  checkPin(pin: string): Promise<boolean>,

  // Remove credentials:
  //deletePassword(): Promise<mixed>,
  //deletePin(): Promise<mixed>,
  //deleteRecovery(): Promise<mixed>,

  // OTP:
  readonly otpKey: string | void, // OTP is enabled if this exists
  readonly otpResetDate: string | void, // A reset is requested if this exists
  //cancelOtpReset(): Promise<mixed>,
  //disableOtp(): Promise<mixed>,
  //enableOtp(timeout?: number): Promise<mixed>,

  // Edge login approval:
  //fetchLobby(lobbyId: string): Promise<EdgeLobby>,

  // Login management:
  logout(): Promise<any>,

  // Master wallet list:
  //readonly allKeys: Array<EdgeWalletInfoFull>,
  //changeWalletStates(walletStates: EdgeWalletStates): Promise<mixed>,
  //createWallet(type: string, keys: any): Promise<string>,
  getFirstWalletInfo(type: string): EdgeWalletInfo | undefined,
  //getWalletInfo(id: string): ?EdgeWalletInfo,
  listWalletIds(): Array<string>,
  listSplittableWalletTypes(walletId: string): Promise<Array<string>>,
  splitWalletInfo(walletId: string, newWalletType: string): Promise<string>,

  // Currency wallets:
  readonly activeWalletIds: Array<string>,
  readonly archivedWalletIds: Array<string>,
  readonly currencyWallets: { [walletId: string]: EdgeCurrencyWallet },
  createCurrencyWallet(type: string, opts?: EdgeCreateCurrencyWalletOptions): Promise<EdgeCurrencyWallet>,
  waitForCurrencyWallet(walletId: string): Promise<EdgeCurrencyWallet>,

  // Web compatibility:
  //signEthereumTransaction(
  //  walletId: string,
  //  transaction: EthererumTransaction
  //): Promise<string>,

  // Swapping:
  //fetchSwapCurrencies(): Promise<EdgeSwapCurrencies>,
  //fetchSwapQuote(opts: EdgeSwapQuoteOptions): Promise<EdgeSwapQuote>,

  // Deprecated names:
  //readonly pluginData: EdgePluginData,
  //readonly exchangeCache: EdgeRateCache,
  readonly currencyTools: { [pluginName: string]: EdgeCurrencyConfig },
  //readonly exchangeTools: { [pluginName: string]: EdgeSwapConfig },
  //getExchangeCurrencies(): Promise<EdgeSwapCurrencies>,
  //getExchangeQuote(opts: EdgeSwapQuoteOptions): Promise<EdgeSwapQuote>
}