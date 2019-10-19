
namespace Client.Features.Edge.EdgeAccount.ChangePassword
{
  using FluentValidation;
  using Shared;
  using static Client.Features.Edge.EdgeAccount.ChangePassword.EdgeAccountState;

  public class ChangePasswordValidator : AbstractValidator<ChangePasswordAction>

  {
    public ChangePasswordValidator()
    {

      RuleFor(aChangePasswordAction => aChangePasswordAction.NewPassword).NotEmpty();
      RuleFor(aChangePasswordAction => aChangePasswordAction.NewPassword)
        .Matches(RegularExpressions.PasswordValidation)
        .WithMessage("Requires At Least 6 Characters with 1 Capital Letter, 1 Number and 1 Special Character");
      RuleFor(aChangePasswordAction => aChangePasswordAction.ConfirmPassword)
        .Equal(aChangePasswordAction => aChangePasswordAction.NewPassword)
        .WithMessage("Passwords Don't Match!");
    }

  }
}
