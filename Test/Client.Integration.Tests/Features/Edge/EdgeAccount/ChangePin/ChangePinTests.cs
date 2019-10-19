namespace Client.Integration.Tests.Features.Edge.EdgeAccount.ChangePin
{
  using Client.Features.Edge.EdgeAccount.ChangePin;
  using FluentValidation;
  using FluentValidation.Results;
  using Shouldly;
  using static Client.Features.Edge.EdgeAccount.ChangePin.EdgeAccountState;

  internal class ChangePinTests
  {
    public void PinNotBeLongEnough()
    {
      // Arrange

      var changePinAction = new ChangePinAction()
      {
        NewPin = "22",
        ConfirmPin = "22"
      };

      var changePinValidator = new ChangePinValidator();

      // Act

      ValidationResult validationResult = changePinValidator.Validate(changePinAction);

      // Assert
      validationResult.IsValid.ShouldBe(false);
      validationResult.Errors.Count.ShouldBe(1);
    }

    public void PinShouldBeValid()
    {
      // Arrange

      var changePinAction = new ChangePinAction()
      {
        NewPin = "1234",
        ConfirmPin = "1234"
      };

      var changePinValidator = new ChangePinValidator();

      // Act

      ValidationResult validationResult = changePinValidator.Validate(changePinAction);

      // Assert
      validationResult.IsValid.ShouldBe(true);
      validationResult.Errors.Count.ShouldBe(0);
    }

    public void PinShouldFailBecauseOfNoNum()
    {
      // Arrange

      var changePinAction = new ChangePinAction
      {
        NewPin = "eeee",
        ConfirmPin = "eeee"
      };

      var changePinValidator = new ChangePinValidator();

      // Act

      ValidationResult validationResult = changePinValidator.Validate(changePinAction);

      // Assert
      validationResult.IsValid.ShouldBe(false);
      validationResult.Errors.Count.ShouldBe(1);
    }

    public void PinShouldFailBecauseOfSpace()
    {
      // Arrange

      var changePinAction = new ChangePinAction()
      {
        NewPin = "1 44",
        ConfirmPin = "1 44"
      };

      var changePinValidator = new ChangePinValidator();

      // Act

      ValidationResult validationResult = changePinValidator.Validate(changePinAction);

      // Assert
      validationResult.IsValid.ShouldBe(false);
      validationResult.Errors.Count.ShouldBe(1);
    }

    public void PinShouldNotBeValid()
    {
      // Arrange

      var changePinAction = new ChangePinAction();
      var changePinValidator = new ChangePinValidator();

      // Act

      ValidationResult validationResult = changePinValidator.Validate(changePinAction);

      // Assert
      validationResult.IsValid.ShouldBe(false);
      validationResult.Errors.Count.ShouldBe(1);
      ValidationFailure validationFailure = validationResult.Errors[0];

      validationFailure.PropertyName.ShouldBe(nameof(changePinAction.NewPin));

      validationFailure.Severity.ShouldBe(Severity.Error);
    }

    public void PinShouldNotMatch()
    {
      // Arrange

      var changePinAction = new ChangePinAction()
      {
        NewPin = "1111",
        ConfirmPin = "2222"
      };

      var changePinValidator = new ChangePinValidator();

      // Act

      ValidationResult validationResult = changePinValidator.Validate(changePinAction);

      // Assert
      validationResult.IsValid.ShouldBe(false);
      validationResult.Errors.Count.ShouldBe(1);
    }

    //public void PinShouldFailBecauseOfNoSpecChar()
    //{
    //  // Arrange

    //  var changePinAction = new ChangePinAction
    //  {
    //    NewPin = "NoSp3cialChar"
    //  };

    //  var changePinValidator = new ChangePinValidator;

    //  // Act

    //  ValidationResult validationResult = changePinValidator.Validate(changePinAction);

    //  // Assert
    //  validationResult.IsValid.ShouldBe(false);
    //  validationResult.Errors.Count.ShouldBe(1);

    //}
  }
}