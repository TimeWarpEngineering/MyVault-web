
namespace Client.Features.Edge.EdgeCurrencyWallet.GetEdgeCurrencyWallet
{
  using System;
  using System.Collections.Generic;
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using Client.Features.Base;
  using Client.Features.Edge.State;

  public class UpdateEdgeCurrencyWalletHandler : BaseHandler<UpdateEdgeCurrencyWalletAction, EdgeCurrencyWalletsState>
  {
    public UpdateEdgeCurrencyWalletHandler(IStore aStore) : base(aStore)
    { }

    public override async Task<EdgeCurrencyWalletsState> Handle(UpdateEdgeCurrencyWalletAction aUpdateEdgeCurrencyWalletAction, CancellationToken aCancellationToken)
    {
      MapActionToState(aUpdateEdgeCurrencyWalletAction);

      return await Task.FromResult(EdgeCurrencyWalletsState);
    }

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
  }
}
