namespace Client.Features.Edge
{
  using MediatR;

  /// <summary>
  /// The request sent onLogin
  /// </summary>
  public class OnLoginAction : IRequest<EdgeState> { }
}