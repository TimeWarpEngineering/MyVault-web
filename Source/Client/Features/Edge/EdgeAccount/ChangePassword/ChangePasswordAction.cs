namespace Client.Features.Edge.EdgeAccount.ChangePassword
{
  using Client.Features.Edge.EdgeAccount;
  using Shared.Features.Base;
  using MediatR;

  public class ChangePasswordAction : BaseRequest, IRequest<EdgeAccountState>
  {
    public string NewPassword { get; set; }
    public string ConfirmPassword { get; set; }

  }
}