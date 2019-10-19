namespace Client.Features.Edge
{
  using Client.Features.Base;
  using Shared.Enumerations.FeeOption;

  public partial class EdgeCurrencyWalletsState
  {
    public class SendAction : BaseAction
    {
      public string CurrencyCode { get; set; } = string.Empty;
      public string DestinationAddress { get; set; } = string.Empty;
      public string EdgeCurrencyWalletId { get; set; } = string.Empty;
      public FeeOption Fee { get; set; } = FeeOption.Standard;

      /// <summary>
      /// The amount without decimals. For ETH the native amount unit is called wei. 1x10^18 wei = 1 ETH
      /// </summary>
      public string NativeAmount { get; set; } = string.Empty;
    }
  }
}