namespace Herc.Pwa.Client.Features.Edge.EdgeAccount.ChangePassword
{
  using System;
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using Herc.Pwa.Client.Features.Base;
  using Herc.Pwa.Client.Features.Edge.Dtos;
  using Herc.Pwa.Client.Features.Edge.EdgeAccount;
  using MediatR;
  using Microsoft.JSInterop;

  public class ChangePasswordHandler : BaseHandler<ChangePasswordAction, EdgeAccountState>
  {


    public ChangePasswordHandler(
      IStore aStore,
      IMediator aMediator) : base(aStore)
    {
      Mediator = aMediator;
    }

    private IMediator Mediator { get; }


    public override async Task<EdgeAccountState> Handle(ChangePasswordAction aChangePasswordAction, CancellationToken aCancellationToken)
    {
      ChangePasswordDto changePasswordDto = MapSendActionToChangePasswordDto(aChangePasswordAction);

      Console.WriteLine("Call the jsinterop to change PW via Edge");
      //  not sure about this line
      string changePassResults = await JSRuntime.Current.InvokeAsync<string>(EdgeInteropMethodNames.EdgeAccountInterop_ChangePassword, changePasswordDto);
      Console.WriteLine($"whatever Comes Back from ChangePass:{changePassResults}");

      return await Task.FromResult(EdgeAccountState);
    }

    private ChangePasswordDto MapSendActionToChangePasswordDto(ChangePasswordAction aChangePasswordAction)
    {
      return new ChangePasswordDto
      {
        NewPassword = aChangePasswordAction.NewPassword
      };
    }
  }
}

