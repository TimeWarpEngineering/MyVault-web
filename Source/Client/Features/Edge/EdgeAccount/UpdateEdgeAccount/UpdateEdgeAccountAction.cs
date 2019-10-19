namespace Client.Features.Edge.EdgeAccount
{
  using Client.Features.Base;

  public partial class EdgeAccountState
  {
    public class UpdateEdgeAccountAction : BaseAction
    {
      public string Id { get; set; }
      public bool LoggedIn { get; set; }
      public string Username { get; set; }
    }
  }
}