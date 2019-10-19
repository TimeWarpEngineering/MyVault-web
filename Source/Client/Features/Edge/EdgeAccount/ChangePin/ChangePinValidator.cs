
namespace Client.Features.Edge.EdgeAccount.ChangePin
{
  using FluentValidation;
  using Shared;
  using static Client.Features.Edge.EdgeAccount.ChangePin.EdgeAccountState;

  public class ChangePinValidator : AbstractValidator<ChangePinAction>

  {
    public ChangePinValidator()
    {
      CascadeMode = CascadeMode.StopOnFirstFailure;

      RuleFor(aChangePinAction => aChangePinAction.NewPin).NotEmpty();
      RuleFor(aChangePinAction => aChangePinAction.NewPin)
        .Matches(RegularExpressions.PinValidation)
        .WithMessage("Requires 4 Numbers 0-9");
      RuleFor(aChangePinAction => aChangePinAction.ConfirmPin)
        .Equal(aChangePinAction => aChangePinAction.NewPin)
        .WithMessage("Pins Don't Match!");
    }

  }
}
