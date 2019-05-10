using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Shared.Features.Conversion;

namespace Client.Features.Conversion.AgldRate
{
  public class AgldGetRateAction : IRequest<AgldRateState>
  {
    public decimal AgldRate { get; set; }

    
  }
}
