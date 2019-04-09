//import { EdgeUserInfo } from './EdgeUserInfo';
//import { EdgeAccount } from './EdgeAccount';

export interface EdgeUiContext {
  readonly on: any; // Subscriber<mixed>
  readonly watch: any; // Subscriber<mixed>
  readonly localUsers: import('./EdgeUserInfo').EdgeUserInfo[];
  readonly windowVisible: boolean;
  hideWindow(): Promise<any>; // Promise<mixed>
  showLoginWindow(): Promise<any>; // Promise<mixed>
  //showAccountSettingsWindow(account: import('./EdgeAccount').EdgeAccount): Promise<mixed>; 
  close(): any; // mixed
}