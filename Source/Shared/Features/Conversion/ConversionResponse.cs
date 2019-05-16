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
      public decimal C { get; set; }
      public decimal H { get; set; }
      public decimal L { get; set; }
      public decimal O { get; set; }
      public DateTime Ts { get; set; }
    }
  }
}
