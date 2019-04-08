namespace Herc.Pwa.Client.Features.Edge.EdgeAccount.ChangePin
{
  using Herc.Pwa.Client.Features.Edge.EdgeAccount;
  using Herc.Pwa.Shared.Features.Base;
  using MediatR;

  public class ChangePinAction : BaseRequest, IRequest<EdgeAccountState>
  {
    public string NewPin { get; set; }
    public string ConfirmPin { get; set; }
    public bool EnableLogin { get; set; }


  }
}