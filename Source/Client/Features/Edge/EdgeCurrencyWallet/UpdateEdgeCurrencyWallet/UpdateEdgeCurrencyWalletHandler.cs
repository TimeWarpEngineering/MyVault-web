namespace Client.Features.Edge
{
  using BlazorState;
  using Client.Features.Base;
  using Client.Features.Edge.State;
  using MediatR;
  using System;
  using System.Collections.Generic;
  using System.Threading;
  using System.Threading.Tasks;
  using static Client.Features.Edge.EdgeCurrencyWalletsState;

  public class UpdateEdgeCurrencyWalletHandler : BaseHandler<UpdateEdgeCurrencyWalletAction>
  {
    public UpdateEdgeCurrencyWalletHandler(IStore aStore) : base(aStore) { }

    private void MapActionToState(UpdateEdgeCurrencyWalletAction aUpdateEdgeCurrencyWalletAction)
    {
      if (!EdgeCurrencyWalletsState.EdgeCurrencyWallets.ContainsKey(aUpdateEdgeCurrencyWalletAction.Id))
      {
        EdgeCurrencyWalletsState.EdgeCurrencyWallets[aUpdateEdgeCurrencyWalletAction.Id] = new EdgeCurrencyWallet();
      }
      EdgeCurrencyWallet edgeCurrencyWallet = EdgeCurrencyWalletsState.EdgeCurrencyWallets[aUpdateEdgeCurrencyWalletAction.Id];
      edgeCurrencyWallet.Id = aUpdateEdgeCurrencyWalletAction.Id;
      edgeCurrencyWallet.FiatCurrencyCode = aUpdateEdgeCurrencyWalletAction.FiatCurrencyCode;
      edgeCurrencyWallet.Keys = aUpdateEdgeCurrencyWalletAction.Keys;
      edgeCurrencyWallet.Balances = aUpdateEdgeCurrencyWalletAction.Balances;
      edgeCurrencyWallet.Name = aUpdateEdgeCurrencyWalletAction.Name;
      edgeCurrencyWallet.EdgeTransactions = MapEdgeTransactions(aUpdateEdgeCurrencyWalletAction);
    }

    private List<EdgeTransaction> MapEdgeTransactions(UpdateEdgeCurrencyWalletAction aUpdateEdgeCurrencyWalletAction)
    {
      var edgeTransactions = new List<EdgeTransaction>();
      aUpdateEdgeCurrencyWalletAction.EdgeTransactions.ForEach(
        (aEdgeTransaction) =>
        {
          var edgeTransaction = new EdgeTransaction
          {
            CurrencyCode = aEdgeTransaction.CurrencyCode,
            BlockHeight = aEdgeTransaction.BlockHeight,
            Date = UnixTimeStampToDateTime(unixTimeStamp: aEdgeTransaction.Date),
            NativeAmount = aEdgeTransaction.NativeAmount,
            NetworkFee = aEdgeTransaction.NetworkFee,
            OurReceiveAddresses = aEdgeTransaction.OurReceiveAddresses,
            ParentNetworkFee = aEdgeTransaction.ParentNetworkFee,
            SignedTx = aEdgeTransaction.SignedTx,
            TxId = aEdgeTransaction.TxId
          };
          Console.WriteLine(aEdgeTransaction);

          edgeTransactions.Add(edgeTransaction);
        });

      return edgeTransactions;
    }

    public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
    {
      // Unix timestamp is seconds past epoch
      var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
      dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
      return dtDateTime;
    }

    public override Task<Unit> Handle(UpdateEdgeCurrencyWalletAction aUpdateEdgeCurrencyWalletAction, CancellationToken aCancellationToken)
    {
      MapActionToState(aUpdateEdgeCurrencyWalletAction);

      return Unit.Task;
    }
  }
}