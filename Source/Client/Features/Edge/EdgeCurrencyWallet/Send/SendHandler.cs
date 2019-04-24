namespace Client.Features.Edge.EdgeCurrencyWallet
{
  using System;
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using Client.Features.Base;
  using Client.Features.Edge.Dtos;
  using MediatR;
  using Microsoft.AspNetCore.Components;
  using Microsoft.JSInterop;

  public class SendHandler : BaseHandler<SendAction, EdgeCurrencyWalletsState>
  {
    public SendHandler(IStore aStore, IMediator aMediator) : base(aStore)
    {
      Mediator = aMediator;
    }

    private IMediator Mediator { get; }
    [Inject] IJSRuntime JSRuntime { get; }
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
