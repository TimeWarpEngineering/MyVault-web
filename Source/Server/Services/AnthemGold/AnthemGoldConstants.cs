using Ardalis.SmartEnum;

namespace Server.Services.AnthemGold
{
  public class AnthemGoldConstants
  {
    public const string AgldCurrencyCode = "AGLD";
    public const string BaseUrl = @"https://chart.anthemgold.com/";
    public const string PriceUrl = @"service-1.0-SNAPSHOT/PRICE";
    public const string UsdCurrencyCode = "USD";

    //?symbol=USDAGLD&range=MINUTE_1";

    public sealed class RangeEnum : SmartEnum<RangeEnum>
    {
      public static readonly RangeEnum MINUTE_1 = new RangeEnum(nameof(MINUTE_1), 1);
      public static readonly RangeEnum MINUTE_5 = new RangeEnum(nameof(MINUTE_5), 1);

      private RangeEnum(string aName, int aValue) : base(aName, aValue) { }
    }
  }
}