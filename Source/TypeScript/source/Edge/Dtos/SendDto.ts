export const enum FeeOption {
  Low = "low",
  Standard = "standard",
  High = "high"
}

export interface SendDto {
  edgeCurrencyWalletId: string;
  destinationAddress: string;
  nativeAmount: string;
  currencyCode: string;
  fee: FeeOption;
}