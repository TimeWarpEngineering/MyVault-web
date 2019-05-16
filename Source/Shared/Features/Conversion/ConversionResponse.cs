namespace Shared.Features.Conversion
{
  using Shared.Features.Base;
  using System;
  using System.Collections.Generic;

  public class ConversionResponse : BaseResponse
  {
    public class SingleSymbolPriceResponse
    {
      public Dictionary<string, decimal> Prices { get; set; }
    }

    public class PriceResponse

    {
      public decimal Rate { get; set; }
    }
  }
}
