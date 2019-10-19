namespace Client.Features.Edge.EdgeAccount.ChangePin
{
  using Client.Features.Base;

  public partial class EdgeAccountState
  {
    public class ChangePinAction : BaseAction
    {
      public string ConfirmPin { get; set; }
      public bool EnableLogin { get; set; }
      public string NewPin { get; set; }
    }
  }
}