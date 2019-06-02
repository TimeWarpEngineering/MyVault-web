namespace Client.Components
{
  using System.Collections.Generic;
  using System.Linq;
  using FluentValidation.Results;
  using Microsoft.AspNetCore.Components;

  public class ValidationModel : BaseComponent
  {
    [Parameter] protected ValidationResult ValidationResult { get; set; }

    public IEnumerable<ValidationFailure> OtherErrors => 
      ValidationResult.Errors.Where(aValidationFailure => !aValidationFailure.ErrorMessage.Contains("must not be empty"));

    public IEnumerable<ValidationFailure> RequiredErrors =>
      ValidationResult.Errors.Where(aValidationFailure => aValidationFailure.ErrorMessage.Contains("must not be empty"));

    public bool ShowRequired => RequiredErrors.Any();

  }
}
