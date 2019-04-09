import { EdgeCurrencyWallet } from "./EdgeCurrencyWallet";
import { EdgeMetadata } from "./EdgeMetadata";

export interface EdgeSpendTarget {
  currencyCode?: string,
  destWallet?: EdgeCurrencyWallet,
  publicAddress?: string,
  nativeAmount?: string,
  destMetadata?: EdgeMetadata,
  otherParams?: Object
}