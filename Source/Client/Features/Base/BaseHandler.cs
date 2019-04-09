namespace Herc.Pwa.Client.Features.Base
{
  using BlazorState;
  using Herc.Pwa.Client.Features.Application;
  using Herc.Pwa.Client.Features.Edge;
  using Herc.Pwa.Client.Features.Edge.EdgeAccount;
  using Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet;
  using MediatR;

  /// <summary>
  /// Base Handler that makes it easy to access state
  /// </summary>
  /// <typeparam name="TRequest"></typeparam>
  /// <typeparam name="TState"></typeparam>
  public abstract class BaseHandler<TRequest, TState> : BlazorState.RequestHandler<TRequest, TState>
    where TRequest : IRequest<TState>
    where TState : IState
  {
    public BaseHandler(IStore aStore) : base(aStore) { }

    public ApplicationState ApplicationState => Store.GetState<ApplicationState>();
    public EdgeState EdgeState => Store.GetState<EdgeState>();
    public EdgeCurrencyWalletsState EdgeCurrencyWalletsState => Store.GetState<EdgeCurrencyWalletsState>();
    public EdgeAccountState EdgeAccountState => Store.GetState<EdgeAccountState>();
  }
}