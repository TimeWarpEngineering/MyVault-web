namespace Client.Features.Edge.EdgeAccount.ChangePassword
{
  using BlazorState;
  using Client.Features.Base;
  using Client.Features.Edge.Dtos;
  using MediatR;
  using Microsoft.JSInterop;
  using System;
  using System.Threading;
  using System.Threading.Tasks;
  using static Client.Features.Edge.EdgeAccount.ChangePassword.EdgeAccountState;

  public class ChangePasswordHandler : BaseHandler<ChangePasswordAction>
  {
    public ChangePasswordHandler(IStore aStore, IJSRuntime aJSRuntime) : base(aStore)
    {
      JSRuntime = aJSRuntime;
    }

    private IJSRuntime JSRuntime { get; }

    private ChangePasswordDto MapSendActionToChangePasswordDto(ChangePasswordAction aChangePasswordAction)
    {
      return new ChangePasswordDto
      {
        NewPassword = aChangePasswordAction.NewPassword
      };
    }

    public override async Task<Unit> Handle(ChangePasswordAction aChangePasswordAction, CancellationToken aCancellationToken)
    {
      ChangePasswordDto changePasswordDto = MapSendActionToChangePasswordDto(aChangePasswordAction);

      Console.WriteLine("Call the jsinterop to change PW via Edge");
      //  not sure about this line
      string changePassResults = await JSRuntime.InvokeAsync<string>(EdgeInteropMethodNames.EdgeAccountInterop_ChangePassword, changePasswordDto);
      Console.WriteLine($"whatever Comes Back from ChangePass:{changePassResults}");

      return Unit.Value;
    }
  }
}