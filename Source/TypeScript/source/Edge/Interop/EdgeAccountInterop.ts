import { EdgeAccount } from "../TypeDefinitions/EdgeAccount";
import { EdgeCurrencyWalletInterop } from "./EdgeCurrencyWalletInterop";
import { BlazorState } from "../../BlazorState";
import { BlazorStateName, DotNetActionQualifiedNames } from "../../Constants";
import { UpdateEdgeAccountAction } from "../Actions/UpdateEdgeAccount";
import { EdgeCurrencyWallet } from "../TypeDefinitions/EdgeCurrencyWallet";
import { SendDto } from "../Dtos/SendDto";
import { ChangePasswordDto } from "../Dtos/ChangePasswordDto";
import { ChangePinDto } from "../Dtos/ChangePinDto";

const EtheriumWalletType: string = "wallet:ethereum";

export class EdgeAccountInterop {

  private EdgeAccount: EdgeAccount;
  private EdgeWalletInfo?: EdgeWalletInfo;
  private EdgeCurrencyWalletInterops: { [key: string]: EdgeCurrencyWalletInterop } = {};

  constructor(edgeAccount: EdgeAccount) {
    this.EdgeAccount = edgeAccount;
  }

  public Initialize = async (): Promise<void> => {
    this.ConfigureSubscriptions();
    this.DispatchUpdateEdgeAccount();
    this.EdgeWalletInfo = this.EdgeAccount.getFirstWalletInfo(EtheriumWalletType);
    if (this.EdgeWalletInfo === undefined) {
      const edgeCreateCurrencyWalletOptions: EdgeCreateCurrencyWalletOptions = {
        name: "AGLD Wallet",
        fiatCurrencyCode: "iso:USD"
      }
      this.CreateCurrencyWallet(EtheriumWalletType, edgeCreateCurrencyWalletOptions);
    }
    this.ConfigureCurrencyWallets();
  }

  private ConfigureSubscriptions = () => {

    this.EdgeAccount.watch('username', () => this.DispatchUpdateEdgeAccount());
    this.EdgeAccount.watch('loggedIn', () => this.DispatchUpdateEdgeAccount());
    this.EdgeAccount.watch('id', () => this.DispatchUpdateEdgeAccount());
    this.EdgeAccount.watch('currencyWallets', () => this.ConfigureCurrencyWallets());
    this.EdgeAccount.watch('activeWalletIds', () => this.ConfigureCurrencyWallets());
  }

  private ConfigureCurrencyWallets = async (): Promise<void> => {

    const currencyWallets = this.EdgeAccount.currencyWallets;
    console.log({ currencyWallets });
    if (Object.keys(currencyWallets).length === 0)
      console.log('%cNo CurrencyWallets on EdgeAccount', 'color: purple');
    console.log('%cConfigureCurrencyWallets', 'color: purple');

    Object.keys(currencyWallets).forEach((key) =>
      this.ConfigureCurrencyWalletInterop(currencyWallets[key]));
  }

  private ConfigureCurrencyWalletInterop = (edgeCurrencyWallet: EdgeCurrencyWallet): void => {
    if (this.EdgeCurrencyWalletInterops[edgeCurrencyWallet.id] === undefined) {
      const edgeCurrencyWalletInterop = new EdgeCurrencyWalletInterop(edgeCurrencyWallet);
      this.EdgeCurrencyWalletInterops[edgeCurrencyWallet.id] = edgeCurrencyWalletInterop;
      edgeCurrencyWalletInterop.Initialize();
    }
  }

  private CreateUpdateEdgeAccountAction = (): UpdateEdgeAccountAction => {
    return {
      username: this.EdgeAccount.loggedIn ? this.EdgeAccount.username : undefined,
      id: this.EdgeAccount.id,
      loggedIn: this.EdgeAccount.loggedIn
    };
  }

  private DispatchUpdateEdgeAccount = async (): Promise<void> => {
    console.log('%cDispatchUpdateEdgeAccount', 'color: green');
    const updateEdgeCurrencyWalletAction: UpdateEdgeAccountAction = this.CreateUpdateEdgeAccountAction();
    const blazorState: BlazorState = window[BlazorStateName] as BlazorState;

    blazorState.DispatchRequest(DotNetActionQualifiedNames.UpdateEdgeAccountAction, updateEdgeCurrencyWalletAction);
  }

  private CreateCurrencyWallet = async (aType: string, edgeCreateCurrencyWalletOptions?: EdgeCreateCurrencyWalletOptions): Promise<string> => {
    console.log(`CreateCurrencyWallet with aType:${aType}`);
    const edgeCurrencyWallet = await this.EdgeAccount.createCurrencyWallet(aType, edgeCreateCurrencyWalletOptions);
    this.ConfigureCurrencyWalletInterop(edgeCurrencyWallet);
    return "";
  };

  public Logout = async (): Promise<boolean> => {
    await this.EdgeAccount.logout();
    return true; // TODO blazor doesn't support return of void yet. that I know of
  }

  public Send = async (aSendAction: SendDto): Promise<string> => {
    const edgeCurrencyWalletInterop = this.EdgeCurrencyWalletInterops[aSendAction.edgeCurrencyWalletId];

    return edgeCurrencyWalletInterop.Send(aSendAction);
  }

  public ChangePassword = async (aChangePasswordDto: ChangePasswordDto): Promise<boolean> => {
    await this.EdgeAccount.changePassword(aChangePasswordDto.newPassword);

    return true;
  }

  public ChangePin = async (aChangePinDto: ChangePinDto): Promise<boolean> => {
    await this.EdgeAccount.changePin({ pin: aChangePinDto.newPin, enableLogin: aChangePinDto.enableLogin });
    return true;
  }

}