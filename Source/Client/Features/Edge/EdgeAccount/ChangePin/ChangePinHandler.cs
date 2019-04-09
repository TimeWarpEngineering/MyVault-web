namespace Herc.Pwa.Client.Features.Edge.EdgeAccount.ChangePin
{
  using System;
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using Herc.Pwa.Client.Features.Base;
  using Herc.Pwa.Client.Features.Edge.Dtos;
  using Herc.Pwa.Client.Features.Edge.DTOs;
  using Herc.Pwa.Client.Features.Edge.EdgeAccount;
  using MediatR;
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


    public override async Task<EdgeAccountState> Handle(ChangePinAction aChangePinAction, CancellationToken aCancellationToken)
    {
      ChangePinDto changePinDto = MapSendActionToChangePinDto(aChangePinAction);

      Console.WriteLine("Check if the Data Exists, NewPIn: {0}, EnablePin Login: {1}",  changePinDto.NewPin, changePinDto.EnableLogin);
      //not sure about this line
      string changePinResults = await JSRuntime.Current.InvokeAsync<string>(EdgeInteropMethodNames.EdgeAccountInterop_ChangePin, changePinDto);
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

