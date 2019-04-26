namespace Client.Features.Edge.EdgeAccount.ChangePin
{
  using System;
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using Client.Features.Base;
  using Client.Features.Edge.Dtos;
  using Client.Features.Edge.DTOs;
  using Client.Features.Edge.EdgeAccount;
  using MediatR;
  using Microsoft.AspNetCore.Components;
  using Microsoft.JSInterop;

  public class ChangePinHandler : BaseHandler<ChangePinAction, EdgeAccountState>
  {

    public ChangePinHandler(
      IStore aStore,
      IMediator aMediator) : base(aStore)
    {
      Mediator = aMediator;
    }

    private IMediator Mediator { get; }
    [Inject] IJSRuntime JSRuntime { get; set; }

    public override async Task<EdgeAccountState> Handle(ChangePinAction aChangePinAction, CancellationToken aCancellationToken)
    {
      ChangePinDto changePinDto = MapSendActionToChangePinDto(aChangePinAction);

      Console.WriteLine("Check if the Data Exists, NewPIn: {0}, EnablePin Login: {1}",  changePinDto.NewPin, changePinDto.EnableLogin);
      //not sure about this line
      string changePinResults = await JSRuntime.InvokeAsync<string>(EdgeInteropMethodNames.EdgeAccountInterop_ChangePin, changePinDto);
      Console.WriteLine($"whatever Comes Back from ChangePin:", changePinResults);

      return await Task.FromResult(EdgeAccountState);
    }

    private ChangePinDto MapSendActionToChangePinDto(ChangePinAction aChangePinAction)
    {
      return new ChangePinDto
      {
        NewPin = aChangePinAction.NewPin,
        EnableLogin = aChangePinAction.EnableLogin
      };
    }
  }
}

