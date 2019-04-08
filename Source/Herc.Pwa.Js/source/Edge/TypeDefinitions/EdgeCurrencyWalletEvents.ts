import { EdgeTransaction } from "./EdgeTransaction";

export interface EdgeCurrencyWalletEvents {
  newTransactions: Array<EdgeTransaction>,
  transactionsChanged: Array<EdgeTransaction>
}