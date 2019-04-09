export interface EdgeCurrencyConfig {
  //readonly watch: Subscriber<EdgeCurrencyConfig>,

  //readonly currencyInfo: EdgeCurrencyInfo,
  readonly userSettings: Object,

  //changeUserSettings(settings: Object): Promise<mixed>,

  // Deprecated names:
  settings: Object, // userSettings
  readonly pluginSettings: Object, // userSettings
  //changeSettings(settings: Object): Promise<mixed>,
  //changePluginSettings(settings: Object): Promise<mixed>
}