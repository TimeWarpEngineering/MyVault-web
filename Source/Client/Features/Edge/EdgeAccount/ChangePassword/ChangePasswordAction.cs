namespace Client.Features.Edge.EdgeAccount.ChangePassword
{
  using Client.Features.Base;

  public partial class EdgeAccountState
  {
    public class ChangePasswordAction : BaseAction
    {
      public string ConfirmPassword { get; set; }
      public string NewPassword { get; set; }
    }
  }
}