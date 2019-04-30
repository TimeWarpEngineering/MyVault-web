namespace Server.Features.Conversion
{ 
  using System.Threading.Tasks;
  using Server.Features.Base;
  using Shared.Features.Conversion;
  using MediatR;
  using Microsoft.AspNetCore.Mvc;

  [Route(ConversionRequest.Route)]
  public class ConvertController : BaseController<ConversionRequest, ConversionResponse>
  {
    public ConvertController(IMediator aMediator) : base(aMediator) { }

    [HttpGet]
    public async Task<IActionResult> Get(ConversionRequest aConversionRequest) => await Send(aConversionRequest);
  }
}
