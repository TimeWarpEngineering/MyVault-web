namespace Client.Features.Rate.EthRate
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

  public partial class RateState : State<RateState>
  {
   
    public class EthRate
    {

      public EthRate(IStore aStore, Mediator aMediator) 
      {
        Mediator = aMediator;
      }
    private Mediator Mediator { get; }

    SingleService ConversionRequest = new ConversionRequest() { FromCurrency = "agld", ToCurrency = "usd" };

    public decimal Rate { get; private set; } = await 


    protected override void Initialize() => Rate = 0;
  }
}
}
