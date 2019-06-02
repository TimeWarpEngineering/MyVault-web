namespace Client.Features.Base
{
  using BlazorState;
  using Client.Features.Application;
  using Client.Features.Rate;
  using Client.Features.Edge;
  using Client.Features.Edge.EdgeAccount;
  using Client.Features.Edge.EdgeCurrencyWallet;
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

    public RateState RateState => Store.GetState<RateState>();
    public ApplicationState ApplicationState => Store.GetState<ApplicationState>();
    public EdgeState EdgeState => Store.GetState<EdgeState>();
    public EdgeCurrencyWalletsState EdgeCurrencyWalletsState => Store.GetState<EdgeCurrencyWalletsState>();
    public EdgeAccountState EdgeAccountState => Store.GetState<EdgeAccountState>();

  }
}