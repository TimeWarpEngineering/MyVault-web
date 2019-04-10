import { BlazorState } from '../../BlazorState';
import { BlazorStateName, DotNetActionQualifiedNames } from '../../Constants';
import { EdgeCurrencyWallet } from "../TypeDefinitions/EdgeCurrencyWallet";
import { EdgeTokenInfo } from "../TypeDefinitions/EdgeTokenInfo";
import { EdgeCurrencyInfo } from "../TypeDefinitions/EdgeCurrencyInfo";
import { UpdateEdgeCurrencyWalletAction } from '../Actions/UpdateEdgeCurrencyWalletAction';
import { EdgeTransaction } from '../TypeDefinitions/EdgeTransaction';
import { EdgeSpendInfo } from '../TypeDefinitions/EdgeSpendInfo';
import { SendDto, FeeOption } from '../Dtos/SendDto';
import { EdgeGetTransactionsOptions } from '../TypeDefinitions/EdgeGetTransactionsOptions';

export class EdgeCurrencyWalletInterop {
  private EdgeCurrencyWallet: EdgeCurrencyWallet;
  
  private AnthemGoldTokenInfo: EdgeTokenInfo = {
    currencyName: 'AnthemHold',
    contractAddress: '0x62AbD749d52043Cd6A5542247D604491186540c2',
    currencyCode: 'AHLD',
    multiplier: '1000000000'
  };

  constructor(edgeCurrencyWallet: EdgeCurrencyWallet) {
    this.EdgeCurrencyWallet = edgeCurrencyWallet;
    console.log(`EdgeCurrencyWalletInterop constructor ${edgeCurrencyWallet.id}`);
  }

  public async Initialize(): Promise<void> {
    console.log(`Initialize EdgeCurrencyWalletInterop for ${this.EdgeCurrencyWallet.id}`);
    await this.EdgeCurrencyWallet.addCustomToken(this.AnthemGoldTokenInfo);

    const enabledTokens: Array<string> = await this.EdgeCurrencyWallet.getEnabledTokens();
    if (!enabledTokens.includes(this.AnthemGoldTokenInfo.currencyCode)) {      
      await this.EdgeCurrencyWallet.enableTokens([this.AnthemGoldTokenInfo.currencyCode]);
    }
    this.ConfigureSubscriptions();
    this.DispatchUpdateEdgeCurrencyWallet();
  }

  private async ConfigureSubscriptions() {
    this.EdgeCurrencyWallet.watch('balances', () => this.DispatchUpdateEdgeCurrencyWallet());
    this.EdgeCurrencyWallet.watch('currencyInfo', () => this.DispatchUpdateEdgeCurrencyWallet());
    this.EdgeCurrencyWallet.watch('fiatCurrencyCode', () => this.DispatchUpdateEdgeCurrencyWallet());
    this.EdgeCurrencyWallet.watch('id', () => this.DispatchUpdateEdgeCurrencyWallet());
    this.EdgeCurrencyWallet.watch('keys', () => this.DispatchUpdateEdgeCurrencyWallet());
    this.EdgeCurrencyWallet.watch('name', () => this.DispatchUpdateEdgeCurrencyWallet());
    this.EdgeCurrencyWallet.watch('type', () => this.DispatchUpdateEdgeCurrencyWallet());
    this.EdgeCurrencyWallet.on('newTransactions', () => this.DispatchUpdateEdgeCurrencyWallet());
    this.EdgeCurrencyWallet.on('transactionsChanged', () => this.DispatchUpdateEdgeCurrencyWallet());
  }

  getEnabledTokens = (): Promise<string[]> => {
    return this.EdgeCurrencyWallet.getEnabledTokens();
  }

  private GetEdgeCurrencyWalletAction = async (): Promise<UpdateEdgeCurrencyWalletAction> => {
    const currencyInfo: EdgeCurrencyInfo = this.EdgeCurrencyWallet.currencyInfo;
    const enabledTokens: string[] = await this.EdgeCurrencyWallet.getEnabledTokens();
    const transactions: Array<EdgeTransaction> = await this.GetTransactions(enabledTokens);
    return {
      id: this.EdgeCurrencyWallet.id,
      keys: this.EdgeCurrencyWallet.keys,
      balances: this.EdgeCurrencyWallet.balances,
      fiatCurrencyCode: this.EdgeCurrencyWallet.fiatCurrencyCode,
      name: this.EdgeCurrencyWallet.name,
      edgeTransactions: transactions,
      enabledTokens
    };
  }

  private GetTransactions = async (enableTokens: string[]): Promise<Array<EdgeTransaction>> => {
    var allEdgeTransactions: EdgeTransaction[] = [];
    for (var index = 0; index < enableTokens.length; index++) {
      const token = enableTokens[index];
      const edgeGetTransactionsOptions: EdgeGetTransactionsOptions = {
        startEntries: 100,
        currencyCode: token
      };
      const edgeTransactions = await this.EdgeCurrencyWallet.getTransactions(edgeGetTransactionsOptions);
      allEdgeTransactions = allEdgeTransactions.concat(edgeTransactions);
    }
    return allEdgeTransactions; 
  }

  private DispatchUpdateEdgeCurrencyWallet = async (): Promise<void> => {
    const updateEdgeCurrencyWalletAction: UpdateEdgeCurrencyWalletAction = await this.GetEdgeCurrencyWalletAction();
    const blazorState: BlazorState = window[BlazorStateName] as BlazorState;
    updateEdgeCurrencyWalletAction.edgeTransactions.forEach((t) => { delete t["amountSatoshi"]});

    blazorState.DispatchRequest(
      DotNetActionQualifiedNames.UpdateEdgeCurrencyWalletAction,
      updateEdgeCurrencyWalletAction);
  }

  public Send = async (aSendDto: SendDto): Promise<string> => {
    console.log(FeeOption.Standard);
    console.log(aSendDto.fee);
    const edgeSpendInfo: EdgeSpendInfo = {
      currencyCode: aSendDto.currencyCode,
      networkFeeOption: <string> aSendDto.fee,
      spendTargets: [
        {
          publicAddress: aSendDto.destinationAddress,
          nativeAmount: aSendDto.nativeAmount
        }
      ]
    }
    var edgeTransaction: EdgeTransaction = await this.EdgeCurrencyWallet.makeSpend(edgeSpendInfo);
    edgeTransaction = await this.EdgeCurrencyWallet.signTx(edgeTransaction);
    await this.EdgeCurrencyWallet.saveTx(edgeTransaction);
    edgeTransaction = await this.EdgeCurrencyWallet.broadcastTx(edgeTransaction);

    return edgeTransaction.txid;
  }

}
