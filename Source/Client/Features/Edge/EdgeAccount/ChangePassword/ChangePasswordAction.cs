namespace Herc.Pwa.Client.Features.Edge.EdgeAccount.ChangePassword
{
  using Herc.Pwa.Client.Features.Edge.EdgeAccount;
  using Herc.Pwa.Shared.Features.Base;
  using MediatR;

  public class ChangePasswordAction : BaseRequest, IRequest<EdgeAccountState>
  {
    public string NewPassword { get; set; }
    public string ConfirmPassword { get; set; }

  }
}