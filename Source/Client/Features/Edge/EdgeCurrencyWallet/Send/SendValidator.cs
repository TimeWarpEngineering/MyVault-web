
namespace Client.Features.Edge.EdgeCurrencyWallet
{
  using System.Numerics;
  using BlazorState;
  using FluentValidation;
  using Nethereum.Util;

  public class SendValidator : AbstractValidator<SendAction>
  {
    private AddressUtil AddressUtil { get; }
    private IStore Store { get; set; }

    private EdgeCurrencyWalletsState EdgeCurrencyWalletsState => Store.GetState<EdgeCurrencyWalletsState>();

    public const string InvalidEthereumAddressMessage = "'{PropertyName}' is not a valid Ethereum address";
    public const string NoWalletForIdMessage = "No wallet found with Id {PropertyValue}";
    public const string MustBeGreaterThanZeroMessage = "'{PropertyName}' must be greater than zero";
    public const string NoCurrencyCodeMessage = "The currency code does not exist in this wallet";
    public const string InsufficentFundsMessage = "You can not send more than your balance";

    public SendValidator(IStore aStore, AddressUtil aAddressUtil)
    {
      AddressUtil = aAddressUtil;
      Store = aStore;

      RuleFor(aSendAction => aSendAction.CurrencyCode)
        .NotEmpty();
      RuleFor(aSendAction => aSendAction.DestinationAddress)
        .NotEmpty();
      RuleFor(aSendAction => aSendAction.DestinationAddress)
        .Must(BeValidEthereumAddress)
        .WithMessage(InvalidEthereumAddressMessage)
        .When(aSendAction => !string.IsNullOrWhiteSpace(aSendAction.DestinationAddress));
      RuleFor(aSendAction => aSendAction.EdgeCurrencyWalletId)
        .NotEmpty()
        .Must(WalletMustExist)
        .WithMessage(aSendAction => NoWalletForIdMessage);
      RuleFor(aSendAction => aSendAction.Fee).NotEmpty();

      RuleFor(aSendAction => aSendAction.NativeAmount)
        .NotEmpty();
      RuleFor(aSendAction => aSendAction.NativeAmount)
        .Must(BeGreaterThanZero)
        .WithMessage(MustBeGreaterThanZeroMessage)
        .When(aSendAction => !string.IsNullOrWhiteSpace(aSendAction.NativeAmount));

      RuleFor(aSendAction => aSendAction)
        .Must(CurrencyMustExistInWallet)
        .WithMessage(NoCurrencyCodeMessage)
        .When(aSendAction => WalletMustExist(aSendAction.EdgeCurrencyWalletId))
        .When(aSendAction => !string.IsNullOrWhiteSpace(aSendAction.CurrencyCode));

      RuleFor(aSendAction => aSendAction)
        .Must(aSendAction => BalanceGreaterThanSendAmount(aSendAction))
        .WithMessage(InsufficentFundsMessage)
        .When(aSendAction => CurrencyMustExistInWallet(aSendAction))
        .When(aSendAction => WalletMustExist(aSendAction.EdgeCurrencyWalletId))
        .When(aSendAction => !string.IsNullOrWhiteSpace(aSendAction.NativeAmount));
    }

    private bool CurrencyMustExistInWallet(SendAction aSendAction)
    {
      return EdgeCurrencyWalletsState
        .EdgeCurrencyWallets[aSendAction.EdgeCurrencyWalletId]
        .Balances
        .ContainsKey(aSendAction.CurrencyCode);
    }

    private bool BeValidEthereumAddress(string aDestinationAddress) =>
        AddressUtil.IsValidEthereumAddressHexFormat(aDestinationAddress);

    private bool WalletMustExist(string aEdgeCurrencyWalletId) =>
      EdgeCurrencyWalletsState.EdgeCurrencyWallets.ContainsKey(aEdgeCurrencyWalletId);

    private bool BeGreaterThanZero(string aNativeAmount)
    {
      return BigInteger.TryParse(aNativeAmount, out BigInteger aValue) ?
        aValue.CompareTo(0) > 0 :
        false;
    }

    private bool BalanceGreaterThanSendAmount(SendAction aSendAction)
    {
      if (BigInteger.TryParse(aSendAction.NativeAmount, out BigInteger aValue))
      {
        var balance = BigInteger.Parse(EdgeCurrencyWalletsState.EdgeCurrencyWallets[aSendAction.EdgeCurrencyWalletId].Balances[aSendAction.CurrencyCode]);
        return balance.CompareTo(aValue) > 0;
      }
      else
      {
        return false;
      }
    }

  }
}
