namespace Client.Features.RateState.EthRate
{
  using BlazorState;
  using System.Threading;
  using System.Threading.Tasks;
  using Shared.Features.Conversion;
  using System.Net.Http;
  using Microsoft.AspNetCore.Components;
  using TimeWarp.Extensions;
  using Client.Features.Base;
  using MediatR;

  //public partial class RateState : State<RateState.EthRateState>
  //{
  //  public class EthRateState
  //  {

  //    public EthRateState(IStore aStore, Mediator aMediator)
  //    {
  //      Mediator = aMediator;
  //    }
  //    private Mediator Mediator { get; }

  //    ConversionResponse.SingleSymbolPriceResponse EthPrice = new ConversionRequest.SingleSymbolPriceRequest() { FromCurrency = "agld", ToCurrency = "usd" };

  //    public decimal Rate { get; private set; };


  //  protected override void Initialize() =>RateState.EthRateState. = 0;
    }
