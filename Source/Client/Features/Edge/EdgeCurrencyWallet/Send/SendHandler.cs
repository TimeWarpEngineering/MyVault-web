namespace Client.Features.Edge.EdgeCurrencyWallet
{
  using System;
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using Client.Features.Base;
  using Client.Features.Edge.Dtos;
  using Microsoft.JSInterop;

  public class SendHandler : BaseHandler<SendAction, EdgeCurrencyWalletsState>
  {
    public SendHandler(IStore aStore, IJSRuntime aJSRuntime) : base(aStore)
    {
      JSRuntime = aJSRuntime;
    }
    public SendHandler(IStore aStore ) : base(aStore) { }
    private IJSRuntime JSRuntime { get; }
    public override async Task<EdgeCurrencyWalletsState> Handle(SendAction aSendAction, CancellationToken aCancellationToken)
    {
      SendDto sendDto = MapSendActionToSendDto(aSendAction);

      string transactionId = await JSRuntime.InvokeAsync<string>(EdgeInteropMethodNames.EdgeCurrencyWalletInterop_Send, sendDto);
      Console.WriteLine($"SendTransactionId:{transactionId}");

      return await Task.FromResult(EdgeCurrencyWalletsState);
    }

    private SendDto MapSendActionToSendDto(SendAction aSendAction)
    {
      return new SendDto
      {
        NativeAmount = aSendAction.NativeAmount,
        CurrencyCode = aSendAction.CurrencyCode,
        DestinationAddress = aSendAction.DestinationAddress,
        EdgeCurrencyWalletId = aSendAction.EdgeCurrencyWalletId,
        Fee = aSendAction.Fee.ToString()
      };
    }
  }
}
