import { EdgeSpendTarget } from "./EdgeSpendTarget";
import { EdgeMetadata } from "./EdgeMetadata";

export interface EdgeSpendInfo {
  currencyCode?: string,
  noUnconfirmed?: boolean,
  privateKeys?: Array<string>,
  spendTargets: Array<EdgeSpendTarget>,
  nativeAmount?: string,
  quoteFor?: string,
  networkFeeOption?: string, // 'high' | 'standard' | 'low' | 'custom',
  customNetworkFee?: any, // Some kind of currency-specific JSON
  metadata?: EdgeMetadata,
  otherParams?: Object
};

