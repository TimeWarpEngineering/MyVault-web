namespace Client.Features.Edge.EdgeAccount.ChangePassword
{
  using System;
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using Client.Features.Base;
  using Client.Features.Edge.Dtos;
  using Client.Features.Edge.EdgeAccount;
  using MediatR;
  using Microsoft.AspNetCore.Components;
  using Microsoft.JSInterop;

  public class ChangePasswordHandler : BaseHandler<ChangePasswordAction, EdgeAccountState>
  {


    public ChangePasswordHandler(IStore aStore, IJSRuntime aJSRuntime) : base(aStore)
    {
      JSRuntime = aJSRuntime;
    }

   
    private IJSRuntime JSRuntime { get; }

    public override async Task<EdgeAccountState> Handle(ChangePasswordAction aChangePasswordAction, CancellationToken aCancellationToken)
    {
      ChangePasswordDto changePasswordDto = MapSendActionToChangePasswordDto(aChangePasswordAction);

      Console.WriteLine("Call the jsinterop to change PW via Edge");
      //  not sure about this line
      string changePassResults = await JSRuntime.InvokeAsync<string>(EdgeInteropMethodNames.EdgeAccountInterop_ChangePassword, changePasswordDto);
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

