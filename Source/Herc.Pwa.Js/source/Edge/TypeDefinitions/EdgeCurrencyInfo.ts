import { EdgeDenomination } from './EdgeDenomination';
import { EdgeMetaToken } from './EdgeMetaToken';

export interface EdgeCurrencyInfo {
  // Basic currency information:
  currencyCode: string,
  currencyName: string,
  pluginName: string,
  denominations: Array<EdgeDenomination>,
  walletTypes: Array<string>,
  requiredConfirmations?: number,

  // Configuration options:
  defaultSettings: any,
  metaTokens: Array<EdgeMetaToken>,

  // Explorers:
  addressExplorer: string,
  blockExplorer?: string,
  transactionExplorer: string,

  // Images:
  symbolImage?: string,
  symbolImageDarkMono?: string
}