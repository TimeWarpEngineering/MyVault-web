namespace Server.Features.Conversion
{
  using System.Threading.Tasks;
  using Server.Features.Base;
  using Shared.Features.Conversion;
  using MediatR;
  using Microsoft.AspNetCore.Mvc;

  [Route(ConversionRequest.Route)]
  public class ConversionController : BaseController<ConversionRequest, ConversionResponse>
  {

    [HttpGet]
    public async Task<IActionResult> Get(ConversionRequest aConversionRequest) => await Send(aConversionRequest);
  }
}
