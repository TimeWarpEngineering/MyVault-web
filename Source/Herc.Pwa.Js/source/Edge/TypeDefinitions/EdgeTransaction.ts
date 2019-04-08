import { EdgeCurrencyWallet } from "./EdgeCurrencyWallet";
import { EdgeMetadata } from "./EdgeMetadata";

export interface EdgeTransaction {
  txid: string,
  date: number,
  currencyCode: string,
  blockHeight: number,
  nativeAmount: string,
  networkFee: string,
  ourReceiveAddresses: Array<string>,
  signedTx: string,
  parentNetworkFee?: string,
  metadata?: EdgeMetadata,
  otherParams: any,
  wallet?: EdgeCurrencyWallet
};