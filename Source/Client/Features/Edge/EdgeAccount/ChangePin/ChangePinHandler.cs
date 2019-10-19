namespace Client.Features.Edge.EdgeAccount.ChangePin
{
  using BlazorState;
  using Client.Features.Base;
  using Client.Features.Edge.DTOs;
  using MediatR;
  using Microsoft.JSInterop;
  using System;
  using System.Threading;
  using System.Threading.Tasks;
  using static Client.Features.Edge.EdgeAccount.ChangePin.EdgeAccountState;

  public class ChangePinHandler : BaseHandler<ChangePinAction>
  {
    public ChangePinHandler(IStore aStore, IJSRuntime aJSRuntime) : base(aStore)
    {
      JSRuntime = aJSRuntime;
    }

    private IJSRuntime JSRuntime { get; }

    private ChangePinDto MapSendActionToChangePinDto(ChangePinAction aChangePinAction)
    {
      return new ChangePinDto
      {
        NewPin = aChangePinAction.NewPin,
        EnableLogin = aChangePinAction.EnableLogin
      };
    }

    public override async Task<Unit> Handle(ChangePinAction aChangePinAction, CancellationToken aCancellationToken)
    {
      ChangePinDto changePinDto = MapSendActionToChangePinDto(aChangePinAction);

      Console.WriteLine("Check if the Data Exists, NewPIn: {0}, EnablePin Login: {1}", changePinDto.NewPin, changePinDto.EnableLogin);
      //not sure about this line
      string changePinResults = await JSRuntime.InvokeAsync<string>(EdgeInteropMethodNames.EdgeAccountInterop_ChangePin, changePinDto);
      Console.WriteLine($"whatever Comes Back from ChangePin:", changePinResults);

      return Unit.Value;
    }
  }
}