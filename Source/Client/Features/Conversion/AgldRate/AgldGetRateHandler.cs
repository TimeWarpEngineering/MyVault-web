using BlazorState;
using System.Threading;
using System.Threading.Tasks;
using Shared.Features.Conversion;
using System.Net.Http;
using Microsoft.AspNetCore.Components;

namespace Client.Features.Conversion.AgldRate
{
  public partial class AgldRateState
  {
    public class AgldGetRateHandler : RequestHandler<AgldGetRateAction, AgldRateState>
    {
      public AgldGetRateHandler(IStore aStore) : base(aStore)
      {
      }
      //AgldRateState AgldRateState => Store.GetState<AgldRateState>();

      public override async Task<AgldGetRateAction> Handle(ConversionRequest aConversionRequest, CancellationToken ACancellationToken)
      {
       ConversionResponse ConversionResponse  = await Send<ConversionResponse>(ConversionRequest.Route);
      }


    }
  }
}
