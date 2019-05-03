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
    public ConversionController(IMediator aMediator) : base(aMediator) { }

    [HttpGet]
    public async Task<IActionResult> Get([FromBody]ConversionRequest aConversionRequest) => await Send(aConversionRequest);
  }
}
