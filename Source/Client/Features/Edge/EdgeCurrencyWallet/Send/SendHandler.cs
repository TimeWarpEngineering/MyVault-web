namespace Client.Features.Edge
{
  using BlazorState;
  using Client.Features.Base;
  using Client.Features.Edge.Dtos;
  using MediatR;
  using Microsoft.JSInterop;
  using System;
  using System.Threading;
  using System.Threading.Tasks;
  using static Client.Features.Edge.EdgeCurrencyWalletsState;

  public class SendHandler : BaseHandler<SendAction>
  {
    public SendHandler(IStore aStore, IJSRuntime aJSRuntime) : base(aStore)
    {
      JSRuntime = aJSRuntime;
    }

    public SendHandler(IStore aStore) : base(aStore) { }

    private IJSRuntime JSRuntime { get; }

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

    public override async Task<Unit> Handle(SendAction aSendAction, CancellationToken aCancellationToken)
    {
      SendDto sendDto = MapSendActionToSendDto(aSendAction);

      string transactionId = await JSRuntime.InvokeAsync<string>(EdgeInteropMethodNames.EdgeCurrencyWalletInterop_Send, sendDto);
      Console.WriteLine($"SendTransactionId:{transactionId}");

      return Unit.Value;
    }
  }
}