namespace Client.Features.Edge.EdgeAccount
{
  using MediatR;
  public class UpdateEdgeAccountAction : IRequest<EdgeAccountState>
  {
    public string Username { get; set; }
    public bool LoggedIn { get; set; }
    public string Id { get; set; }
  }
}
