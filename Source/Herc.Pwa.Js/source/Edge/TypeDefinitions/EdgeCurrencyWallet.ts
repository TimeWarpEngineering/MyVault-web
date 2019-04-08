import { EdgeTokenInfo } from './EdgeTokenInfo';
import { EdgeCurrencyInfo } from './EdgeCurrencyInfo';
import { EdgeBalances } from './EdgeBalances';
import { EdgeCurrencyCodeOptions } from './EdgeCurrencyCodeOptions';
import { EdgeGetTransactionsOptions } from './EdgeGetTransactionsOptions';
import { EdgeTransaction } from './EdgeTransaction';
import { EdgeReceiveAddress } from './EdgeReceiveAddress';
import { EdgeSpendInfo } from './EdgeSpendInfo';
import { EdgeMetadata } from './EdgeMetadata';
import { EdgeCoinExchangeQuote } from './EdgeCoinExchangeQuote';
import { EdgePaymentProtocolInfo } from './EdgePaymentProtocolInfo';
import { EdgeDataDump } from './EdgeDataDump';
import { EdgeParsedUri } from './EdgeParsedUri';
import { EdgeEncodeUri } from './EdgeEncodeUri';
import { Subscriber } from './Subscriber';
import { EdgeCurrencyWalletEvents } from './EdgeCurrencyWalletEvents';

export interface EdgeCurrencyWallet {
  readonly on: Subscriber<EdgeCurrencyWalletEvents>;
  readonly watch: Subscriber<EdgeCurrencyWallet>;

  // Data store:
  readonly id: string;
  readonly keys: any;
  readonly type: string;
  //readonly folder: DiskletFolder;
  //readonly localFolder: DiskletFolder;
  //sync(): Promise<mixed>;

  // Wallet keys:
  readonly displayPrivateSeed: string | null;
  readonly displayPublicSeed: string | null;

  // Wallet name:
  readonly name: string | null;
  //renameWallet(name: string): Promise<mixed>;

  // Fiat currency option:
  readonly fiatCurrencyCode: string,
  //setFiatCurrencyCode(fiatCurrencyCode: string): Promise<mixed>,

  // Currency info:
  readonly currencyInfo: EdgeCurrencyInfo;
  // TODO these two methods dissapear on from the object.  I have no idea why.
  nativeToDenomination(
    nativeAmount: string,
    currencyCode: string
  ): Promise<string>;
  denominationToNative(
    denominatedAmount: string,
    currencyCode: string
  ): Promise<string>;

  // Chain state:
  readonly balances: EdgeBalances;
  readonly blockHeight: number;
  readonly syncRatio: number;

  // Running state:
  //startEngine(): Promise<mixed>;
  //stopEngine(): Promise<mixed>;

  // Token management:
  enableTokens(tokens: Array<string>): Promise<any>;
  //disableTokens(tokens: Array<string>): Promise<mixed>;
  getEnabledTokens(): Promise<Array<string>>;
  addCustomToken(token: EdgeTokenInfo): Promise<any>;

  // Transactions:
  getNumTransactions(opts?: EdgeCurrencyCodeOptions): Promise<number>;
  getTransactions(
    options?: EdgeGetTransactionsOptions
  ): Promise<Array<EdgeTransaction>>;
  getReceiveAddress(
    opts?: EdgeCurrencyCodeOptions
  ): Promise<EdgeReceiveAddress>;
  //saveReceiveAddress(receiveAddress: EdgeReceiveAddress): Promise<mixed>;
  //lockReceiveAddress(receiveAddress: EdgeReceiveAddress): Promise<mixed>;
  makeSpend(spendInfo: EdgeSpendInfo): Promise<EdgeTransaction>;
  signTx(tx: EdgeTransaction): Promise<EdgeTransaction>;
  broadcastTx(tx: EdgeTransaction): Promise<EdgeTransaction>;
  saveTx(tx: EdgeTransaction): Promise<any>;
  sweepPrivateKeys(edgeSpendInfo: EdgeSpendInfo): Promise<EdgeTransaction>;
  //saveTxMetadata(
  //  txid: string,
  //  currencyCode: string,
  //  metadata: EdgeMetadata
  //): Promise<mixed>;
  getMaxSpendable(spendInfo: EdgeSpendInfo): Promise<string>;
  getQuote(spendInfo: EdgeSpendInfo): Promise<EdgeCoinExchangeQuote>;
  getPaymentProtocolInfo(
    paymentProtocolUrl: string
  ): Promise<EdgePaymentProtocolInfo>;

  // Wallet management:
  //resyncBlockchain(): Promise<mixed>;
  dumpData(): Promise<EdgeDataDump>;
  getDisplayPrivateSeed(): string | null;
  getDisplayPublicSeed(): string | null;

  // Data exports:
  exportTransactionsToQBO(opts: EdgeGetTransactionsOptions): Promise<string>;
  exportTransactionsToCSV(opts: EdgeGetTransactionsOptions): Promise<string>;

  // URI handling:
  parseUri(uri: string): Promise<EdgeParsedUri>;
  encodeUri(obj: EdgeEncodeUri): Promise<string>;

  // Deprecated API's:
  getBalance(opts?: EdgeCurrencyCodeOptions): string;
  getBlockHeight(): number;
}