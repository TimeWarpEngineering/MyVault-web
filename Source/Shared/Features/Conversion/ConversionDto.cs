namespace Shared.Features.Conversion
{
  using System;

  public class ConversionDto : ICloneable
  {
    public ConversionDto() { }

    protected ConversionDto(ConversionDto aConversionDto)
    {
      CurrencyA = aConversionDto.CurrencyA;
      CurrencyB = aConversionDto.CurrencyB;
      Rate = aConversionDto.Rate;

    }

    private string CurrencyA { get; set; }

    private string CurrencyB { get; set; }

    private double Rate { get; set; }
    
    public object Clone() => new ConversionDto(this);
  }
}