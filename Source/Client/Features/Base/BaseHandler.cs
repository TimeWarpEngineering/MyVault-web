namespace Client.Features.Base
{
  using BlazorState;
  using Client.Features.Application;
  using Client.Features.Rate;
  using Client.Features.Edge;
  using Client.Features.Edge.EdgeAccount;
  using MediatR;

  /// <summary>
  /// Base Handler that makes it easy to access state
  /// </summary>
  /// <typeparam name="TAction"></typeparam>
  public abstract class BaseHandler<TAction> : ActionHandler<TAction>
    where TAction : IAction
  {
    public BaseHandler(IStore aStore) : base(aStore) { }

    public RateState RateState => Store.GetState<RateState>();
    public ApplicationState ApplicationState => Store.GetState<ApplicationState>();
    public EdgeAccountState EdgeAccountState => Store.GetState<EdgeAccountState>();
    public EdgeCurrencyWalletsState EdgeCurrencyWalletsState => Store.GetState<EdgeCurrencyWalletsState>();
    public EdgeState EdgeState => Store.GetState<EdgeState>();

  }
}