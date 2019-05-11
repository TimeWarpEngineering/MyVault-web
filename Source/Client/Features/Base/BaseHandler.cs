namespace Client.Features.Base
{
  using BlazorState;
  using Client.Features.Application;
  using Client.Features.Conversion.AgldRate;
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

    public AgldRateState AgldRateState => Store.GetState<AgldRateState>();
    public ApplicationState ApplicationState => Store.GetState<ApplicationState>();
    public EdgeState EdgeState => Store.GetState<EdgeState>();
    public EdgeCurrencyWalletsState EdgeCurrencyWalletsState => Store.GetState<EdgeCurrencyWalletsState>();
    public EdgeAccountState EdgeAccountState => Store.GetState<EdgeAccountState>();

  }
}