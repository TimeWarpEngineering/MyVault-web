using BlazorState;
using Client.Features.Base;
using Client.Features.Rate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client.Features.Edge.EdgeCurrencyWallet
{
  public partial class EdgeCurrencyWalletsState
  {
    public class SetSelectedCurrencyCodeHandler : BaseHandler<SetSelectedCurrencyAction, EdgeCurrencyWalletsState>
    {
      public SetSelectedCurrencyCodeHandler(IStore aStore, IMediator aMediator) : base(aStore)
      {
        Mediator = aMediator;
      }

      private IMediator Mediator { get; }

      public override Task<EdgeCurrencyWalletsState> Handle(SetSelectedCurrencyAction aSetSelectedCurrencyAction, CancellationToken aCancellationToken)
      {
        EdgeCurrencyWalletsState.SelectedEdgeCurrencyWallet.SelectedCurrencyCode = aSetSelectedCurrencyAction.CurrencyCode;

        var getRateAction = new GetRateAction
        {
          ToCurrency = EdgeCurrencyWalletsState.SelectedEdgeCurrencyWallet.ShortFiatCurrencyCode,
          FromCurrency = aSetSelectedCurrencyAction.CurrencyCode
        };
        //_ = await Mediator.Send(getRateAction);

        return Task.FromResult(EdgeCurrencyWalletsState);
      }
    }
  }
}
