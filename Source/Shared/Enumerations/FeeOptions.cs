using System.Collections.Generic;

namespace Shared.Enumerations.FeeOption
{
  public partial class FeeOption : Enumeration
  {
    public static readonly FeeOption High = new HighFee();
    public static readonly FeeOption Standard = new StandardFee();
    public static readonly FeeOption Low = new LowFee();

    private FeeOption(int aValue, string aName, List<string> aAlternateCodes = null) : base(aValue, aName, aAlternateCodes) { }

    public class HighFee : FeeOption
    {
      public HighFee() : base(2, "high") { }
    }

    public class StandardFee : FeeOption
    {
      public StandardFee() : base(0, "standard") { }
    }

    public class LowFee : FeeOption
    {
      public LowFee() : base(1, "low") { }
    }
  }
}