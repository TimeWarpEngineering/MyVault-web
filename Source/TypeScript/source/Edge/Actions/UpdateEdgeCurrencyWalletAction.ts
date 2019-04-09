import { EdgeBalances } from "../TypeDefinitions/EdgeBalances";
import { EdgeTransaction } from "../TypeDefinitions/EdgeTransaction";

export interface UpdateEdgeCurrencyWalletAction {
  fiatCurrencyCode: string;
  id: string;
  keys: any;
  balances: EdgeBalances;
  enabledTokens: Array<string>;
  name: string | null;
  edgeTransactions: Array<EdgeTransaction>;
}
