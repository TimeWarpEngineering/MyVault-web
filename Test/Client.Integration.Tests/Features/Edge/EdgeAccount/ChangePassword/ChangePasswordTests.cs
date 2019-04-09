namespace Client.Integration.Tests.Features.Edge.EdgeAccount.ChangePassword
{
  using FluentValidation;
  using FluentValidation.Results;
  using Client.Features.Edge.EdgeAccount.ChangePassword;
  using Shouldly;

  class ChangePasswordTests
  {
    public void PasswordShouldNotBeValid()
    {
      // Arrange

      var changePasswordAction = new ChangePasswordAction();
      var changePasswordValidator = new ChangePasswordValidator();

      // Act

      ValidationResult validationResult = changePasswordValidator.Validate(changePasswordAction);

      // Assert
      validationResult.IsValid.ShouldBe(false);
      validationResult.Errors.Count.ShouldBe(1);
      ValidationFailure validationFailure = validationResult.Errors[0];

      validationFailure.PropertyName.ShouldBe(nameof(changePasswordAction.NewPassword));

      validationFailure.Severity.ShouldBe(Severity.Error);


    }

    public void PasswordShouldNotBeLongEnough()
    {
      // Arrange

      var changePasswordAction = new ChangePasswordAction()
      {
        NewPassword = "Shor!",
        ConfirmPassword = "Shor!"
      };

      var changePasswordValidator = new ChangePasswordValidator();

      // Act

      ValidationResult validationResult = changePasswordValidator.Validate(changePasswordAction);

      // Assert
      validationResult.IsValid.ShouldBe(false);
      validationResult.Errors.Count.ShouldBe(1);
      //additional error of "NewPassword" not being in the correct format


    }


    public void PasswordShouldBeValid()
    {
      // Arrange

      var changePasswordAction = new ChangePasswordAction()
      {
        NewPassword = "should3!NotbeValid",
        ConfirmPassword = "should3!NotbeValid"
      };

      var changePasswordValidator = new ChangePasswordValidator();

      // Act

      ValidationResult validationResult = changePasswordValidator.Validate(changePasswordAction);

      // Assert
      validationResult.IsValid.ShouldBe(true);
      validationResult.Errors.Count.ShouldBe(0);


    }

    public void PasswordShouldNotContainCaps()
    {
      // Arrange

      var changePasswordAction = new ChangePasswordAction()
      {
        NewPassword = "shoulb3valid!",
        ConfirmPassword = "shoulb3valid!"
      };

      var changePasswordValidator = new ChangePasswordValidator();

      // Act

      ValidationResult validationResult = changePasswordValidator.Validate(changePasswordAction);

      // Assert
      validationResult.IsValid.ShouldBe(false);
      validationResult.Errors.Count.ShouldBe(1);
     
    }

    public void PasswordShouldFailBecauseOfSpace()
    {
      // Arrange

      var changePasswordAction = new ChangePasswordAction()
      {
        NewPassword = "shoulD not b3Valid!",
        ConfirmPassword = "shoulD not b3Valid!"
      };

      var changePasswordValidator = new ChangePasswordValidator();

      // Act

      ValidationResult validationResult = changePasswordValidator.Validate(changePasswordAction);

      // Assert
      validationResult.IsValid.ShouldBe(false);
      validationResult.Errors.Count.ShouldBe(1);

    }


    public void PasswordShouldFailBecauseOfNoNum()
    {
      // Arrange

      var changePasswordAction = new ChangePasswordAction()
      {
        NewPassword = "ShouldNotBeValidMissingNumber!",
        ConfirmPassword = "ShouldNotBeValidMissingNumber!"
      };

      var changePasswordValidator = new ChangePasswordValidator();

      // Act

      ValidationResult validationResult = changePasswordValidator.Validate(changePasswordAction);

      // Assert
      validationResult.IsValid.ShouldBe(false);
      validationResult.Errors.Count.ShouldBe(1);

    }

    public void PasswordShouldFailBecauseOfNoSpecChar()
    {
      // Arrange

      var changePasswordAction = new ChangePasswordAction()
      {
        NewPassword = "NoSp3cialChar",
        ConfirmPassword = "NoSp3cialChar"
      };

      var changePasswordValidator = new ChangePasswordValidator();

      // Act

      ValidationResult validationResult = changePasswordValidator.Validate(changePasswordAction);

      // Assert
      validationResult.IsValid.ShouldBe(false);
      validationResult.Errors.Count.ShouldBe(1);

    }

    public void PasswordShouldNotMatch()
    {
      // Arrange

      var changePasswordAction = new ChangePasswordAction()
      {
        NewPassword = "Doesn'tMatch1",
        ConfirmPassword = "NoSp3cialChar"
      };

      var changePasswordValidator = new ChangePasswordValidator();

      // Act

      ValidationResult validationResult = changePasswordValidator.Validate(changePasswordAction);

      // Assert
      validationResult.IsValid.ShouldBe(false);
      validationResult.Errors.Count.ShouldBe(1);

    }

  }
}
