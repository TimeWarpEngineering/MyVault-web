
//namespace Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet.GetEdgeCurrencyWallet
//{
//  using System;
//  using System.Collections.Generic;
//  using System.Linq;
//  using System.Threading;
//  using System.Threading.Tasks;
//  using BlazorState;
//  using Herc.Pwa.Client.Features.Base;
//  using MediatR;
//  using Microsoft.JSInterop;

//  public class GetEdgeCurrencyWalletHandler : BaseHandler<GetEdgeCurrencyWalletAction, EdgeCurrencyWalletsState>
//  {
//    public GetEdgeCurrencyWalletHandler(IStore aStore, IMediator aMediator) : base(aStore)
//    {
//      Mediator = aMediator;
//    }

//    private IMediator Mediator { get; }

//    public override async Task<EdgeCurrencyWalletsState> Handle(GetEdgeCurrencyWalletAction request, CancellationToken aCancellationToken)
//    {
//      // TODO Duplicate Constant find proper home
//      const string EtheriumWalletType = "wallet:ethereum";

//      EdgeCurrencyWalletDto edgeCurrencyWalletDto;

//      if (EdgeState.EdgeWalletInfo != null)
//      {
//        string result = await JSRuntime.Current.InvokeAsync<string>(EdgeInteropMethodNames.EdgeInterop_WaitForCurrencyWallet, EdgeState.EdgeWalletInfo.Id);
//        Console.WriteLine($"WaitForCurrencyWallet:{result}");
//        edgeCurrencyWalletDto = Json.Deserialize<EdgeCurrencyWalletDto>(result);
      
//      }
//      else
//      {
//        Console.WriteLine($"EdgeState.EdgeWalletInfo == null");
//        //EdgeCreateCurrencyWalletOptions EdgeCreateCurrencyWalletOptions = new EdgeCreateCurrtencyWalletOptions;
//        string result = await JSRuntime.Current.InvokeAsync<string>(EdgeInteropMethodNames.EdgeInterop_CreateCurrencyWallet, EtheriumWalletType);
//        Console.WriteLine($"CreateCurrencyWallet:{result}");

//        edgeCurrencyWalletDto = Json.Deserialize<EdgeCurrencyWalletDto>(result);
//      }

//      MapDtoToState(edgeCurrencyWalletDto);

//      return EdgeCurrencyWalletsState;
//    }

//    private void MapDtoToState(EdgeCurrencyWalletDto edgeCurrencyWalletDto)
//    {

//      var edgeBalances = new List<EdgeBalance>();

//      edgeCurrencyWalletDto.Balances.ToList().ForEach(aKvp =>
//      {
//        var edgeBalance = new EdgeBalance()
//        {
//          Balance = aKvp.Value,
//          CurrencyCode = aKvp.Key
//        };
//        edgeBalances.Add(edgeBalance);
//      });

//      EdgeCurrencyWalletsState.EdgeCurrencyWallet = new EdgeCurrencyWallet
//      {
//        Id = edgeCurrencyWalletDto.Id,
//        FiatCurrencyCode = edgeCurrencyWalletDto.FiatCurrencyCode,
//        Keys = edgeCurrencyWalletDto.Keys,
//        EdgeBalances = edgeBalances
//      };
//    }
//  }
//}
