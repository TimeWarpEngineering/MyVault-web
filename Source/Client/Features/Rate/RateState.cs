#nullable enable
namespace Client.Features.Rate
{
  using BlazorState;
  using System;
  using System.Collections.Generic;
  using System.Linq;

  public partial class RateState : State<RateState>
  {
    private List<Conversion> _Conversions;

    public RateState()
    {
      _Conversions = new List<Conversion>();
    }

    public IReadOnlyList<Conversion> Conversions => _Conversions.AsReadOnly();

    public override void Initialize() { }

    public Conversion? GetConversion(string aFromCurrency, string aToCurrency)
    {
      Conversion conversion = Conversions.FirstOrDefault(
        aConversion => aConversion.FromCurrency == aFromCurrency &&
        aConversion.ToCurrency == aToCurrency);

      return conversion;
    }

    public class Conversion
    {
      public Conversion(string aFromCurrency, string aToCurrency, decimal aRate)
      {
        FromCurrency = aFromCurrency;
        ToCurrency = aToCurrency;
        Rate = aRate;
      }

      public string FromCurrency { get; private set; }
      public decimal Rate { get; private set; }
      public string ToCurrency { get; private set; }
      public DateTime TimeStamp { get; } = DateTime.UtcNow;
    }
  }
}