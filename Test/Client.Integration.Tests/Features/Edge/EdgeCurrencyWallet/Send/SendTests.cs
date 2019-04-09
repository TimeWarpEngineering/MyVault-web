namespace Client.Integration.Tests.Features.Edge.EdgeAccount.ChangePassword
{
  using System;
  using System.Linq;
  using BlazorState;
  using BlazorState.Integration.Tests.Infrastructure;
  using FluentValidation;
  using FluentValidation.Results;
  using FluentValidation.Validators;
  using Client.Features.Edge.EdgeCurrencyWallet;
  using Shared.Enumerations.FeeOption;
  using MediatR;
  using Microsoft.Extensions.DependencyInjection;
  using Shouldly;

  internal class SendTests
  {
    private const string WalletId = "1fu3+YTRMVRb6R6uwO7DDCH31iVKkBMtkYHLA0P3hMo=";

    public SendTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
      Store = ServiceProvider.GetService<IStore>();
      SendValidator = ServiceProvider.GetService<IValidator<SendAction>>();
      EdgeCurrencyWalletsState = Store.GetState<EdgeCurrencyWalletsState>();
    }

    private EdgeCurrencyWalletsState EdgeCurrencyWalletsState { get; set; }
    private IMediator Mediator { get; }
    private IServiceProvider ServiceProvider { get; }
    private IStore Store { get; }
    private IValidator<SendAction> SendValidator { get; }
    private EdgeCurrencyWalletsState ValidEdgeCurrencyWalletsState { get; set; }
    private SendAction SendAction { get; set; }

    private const string AgldStartBalance = "1500000000000000000";

    public void Setup()
    {
      // Setup known state valid State.required for a Send to be valid

      ValidEdgeCurrencyWalletsState = new EdgeCurrencyWalletsState();
      // setup wallet

      var edgeCurrencyWallet = new EdgeCurrencyWallet
      {
        SelectedCurrencyCode = "AGLD"
      };
      edgeCurrencyWallet.Balances.Add("AGLD", AgldStartBalance); //1.5 AGLD

      ValidEdgeCurrencyWalletsState.EdgeCurrencyWallets.Add(
        WalletId,
        edgeCurrencyWallet);
      EdgeCurrencyWalletsState.Initialize(ValidEdgeCurrencyWalletsState);

      SendAction = new SendAction
      {
        CurrencyCode = "AGLD",
        DestinationAddress = "0xe3d6f1e0434b870c3b3a0066bdcbffd4ba3f7ea6",
        EdgeCurrencyWalletId = "1fu3+YTRMVRb6R6uwO7DDCH31iVKkBMtkYHLA0P3hMo=",
        NativeAmount = "500000000000000000", // 0.5 AGLD
        Fee = FeeOption.Standard,
      };

    }

    public void CurrencyCodeIsRequired()
    {
      // Arrange

      SendAction.CurrencyCode = "";

      // Act

      ValidationResult validationResult = SendValidator.Validate(SendAction);

      // Assert
      validationResult.IsValid.ShouldBe(false);
      validationResult.Errors.Count.ShouldBe(1);

      ValidationFailure validationFailure = validationResult.Errors[0];
      validationFailure.PropertyName.ShouldBe(nameof(SendAction.CurrencyCode));
      validationFailure.ErrorCode.ShouldBe(nameof(NotEmptyValidator));
      validationFailure.Severity.ShouldBe(Severity.Error);
    }

    public void CurrencyCodeMustBeValid()
    {
      // Arrange

      SendAction.CurrencyCode = "BAD";

      // Act

      ValidationResult validationResult = SendValidator.Validate(SendAction);

      // Assert
      validationResult.IsValid.ShouldBe(false);
      validationResult.Errors.Count.ShouldBe(1);
      ValidationFailure validationFailure = validationResult.Errors[0];

      validationFailure.PropertyName.ShouldBe(string.Empty);
      validationFailure.ErrorCode.ShouldBe(nameof(PredicateValidator));
      validationFailure.Severity.ShouldBe(Severity.Error);
    }

    public void DestinationAddressIsRequired()
    {
      // Arrange

      SendAction.DestinationAddress = "";

      // Act
      ValidationResult validationResult = SendValidator.Validate(SendAction);

      // Assert
      validationResult.IsValid.ShouldBe(false);
      validationResult.Errors.Count.ShouldBeGreaterThan(0);
      ValidationFailure validationFailure = validationResult.Errors
        .First(aValidationFailure => aValidationFailure.ErrorCode == nameof(NotEmptyValidator));

      validationFailure.PropertyName.ShouldBe(nameof(SendAction.DestinationAddress));
      validationFailure.ErrorCode.ShouldBe(nameof(NotEmptyValidator));
      validationFailure.Severity.ShouldBe(Severity.Error);
    }

    public void DestinationAddressMustBeValid()
    {
      // Arrange

      SendAction.DestinationAddress = "ThisIsNotValid";

      // Act
      ValidationResult validationResult = SendValidator.Validate(SendAction);

      // Assert
      validationResult.IsValid.ShouldBe(false);
      validationResult.Errors.Count.ShouldBe(1);
      ValidationFailure validationFailure = validationResult.Errors[0];

      validationFailure.PropertyName.ShouldBe(nameof(SendAction.DestinationAddress));
      validationFailure.ErrorCode.ShouldBe(nameof(PredicateValidator));
      validationFailure.Severity.ShouldBe(Severity.Error);
    }

    public void FeeIsRequired()
    {
      // Arrange
      SendAction.Fee = null;

      // Act
      ValidationResult validationResult = SendValidator.Validate(SendAction);

      // Assert
      validationResult.IsValid.ShouldBe(false);
      validationResult.Errors.Count.ShouldBe(1);
      ValidationFailure validationFailure = validationResult.Errors[0];

      validationFailure.PropertyName.ShouldBe(nameof(SendAction.Fee));
      validationFailure.ErrorCode.ShouldBe(nameof(NotEmptyValidator));
      validationFailure.Severity.ShouldBe(Severity.Error);
    }

    public void NativeAmountMustBeGreaterThanZero()
    {
      // Arrange
      SendAction.NativeAmount = "0000";
      
      // Act

      ValidationResult validationResult = SendValidator.Validate(SendAction);

      // Assert
      validationResult.IsValid.ShouldBe(false);
      validationResult.Errors.Count.ShouldBe(1);
      ValidationFailure validationFailure = validationResult.Errors[0];

      validationFailure.PropertyName.ShouldBe(nameof(SendAction.NativeAmount));
      validationFailure.ErrorCode.ShouldBe(nameof(PredicateValidator));
      validationFailure.Severity.ShouldBe(Severity.Error);
    }

    public void NativeAmountMustBeLessThanBalance()
    {
      // Arrange
      SendAction.NativeAmount = $"1{AgldStartBalance}"; // Greater than Balance
      
      // Act

      ValidationResult validationResult = SendValidator.Validate(SendAction);

      // Assert
      validationResult.IsValid.ShouldBe(false);
      validationResult.Errors.Count.ShouldBe(1);

      ValidationFailure validationFailure = validationResult.Errors[0];
      validationFailure.PropertyName.ShouldBe(string.Empty);
      validationFailure.ErrorCode.ShouldBe(nameof(PredicateValidator));
      validationFailure.Severity.ShouldBe(Severity.Error);
    }

    public void ShouldBeValid()
    {
      // Arrange

      // Act

      ValidationResult validationResult = SendValidator.Validate(SendAction);

      // Assert
      validationResult.IsValid.ShouldBe(true);
    }

    public void WalletMustExist()
    {
      SendAction.EdgeCurrencyWalletId = "x";
        
      // Act

      ValidationResult validationResult = SendValidator.Validate(SendAction);

      // Assert
      validationResult.IsValid.ShouldBe(false);
      validationResult.Errors.Count.ShouldBe(1);

      ValidationFailure validationFailure = validationResult.Errors[0];
      validationFailure.PropertyName.ShouldBe(nameof(SendAction.EdgeCurrencyWalletId));
      validationFailure.ErrorCode.ShouldBe(nameof(PredicateValidator));
      validationFailure.Severity.ShouldBe(Severity.Error);
    }
  }
}