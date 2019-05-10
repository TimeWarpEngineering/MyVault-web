using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorState;
using Shared.Features.Conversion;

namespace Client.Features.Conversion.AgldRate

{
  public partial class AgldRateState : State<AgldRateState>
  {
    public decimal AgldRate { get; private set; }

    protected override void Initalize() => AgldRate = await Task<ConversionResponse> HttpClient.GetJsonAsync<ConversionResponse>(ConversionRequest.Route);


  }
}

