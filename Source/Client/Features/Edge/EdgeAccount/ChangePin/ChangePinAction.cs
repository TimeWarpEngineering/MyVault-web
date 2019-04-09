namespace Client.Features.Edge.EdgeAccount.ChangePin
{
  using Client.Features.Edge.EdgeAccount;
  using Shared.Features.Base;
  using MediatR;

  public class ChangePinAction : BaseRequest, IRequest<EdgeAccountState>
  {
    public string NewPin { get; set; }
    public string ConfirmPin { get; set; }
    public bool EnableLogin { get; set; }


  }
}