namespace Herc.Pwa.Client.Pages
{
  using System;
  using System.Threading.Tasks;
  using FluentValidation.Results;
  using Herc.Pwa.Client.Components;
  using Herc.Pwa.Client.Features.Edge.EdgeAccount.ChangePin;


  public class ChangePinModel : BaseComponent
  {
    public const string Route = "/changePin";
    public string NewPin { get; set; }
    public string ConfirmPin { get; set; }
    public bool EnableLogin { get; set; }
    public ValidationResult ValidationResult { get; set; }

    protected async Task ChangePin()
    {

      var changePinAction = new ChangePinAction
      {
        NewPin = NewPin,
        ConfirmPin = ConfirmPin,
        EnableLogin = EnableLogin
      };

      var validator = new ChangePinValidator();

      ValidationResult = validator.Validate(changePinAction);
      if (ValidationResult.IsValid)
      {
        await Mediator.Send(changePinAction);
        // Upon successful resolve of the above function pop the modal here
        // @showModal = true
        Console.WriteLine("Change the Route to the Home Page.");
        await Mediator.Send(new BlazorState.Features.Routing.ChangeRouteRequest { NewRoute = HomeModel.Route });
      }

    }
  }
}