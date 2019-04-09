using Client.Services;
using Shouldly;

namespace Client.Integration.Tests.Services
{
  public class BalanceFormaterTests
  {

    public void Should_Display_Proper_Decimals()
    {
      var balanceFormater = new AmountConverter();
      var balanceFormaterRequest = new FormatAmountRequest
      {
        Amount = "9979261128182853278",
        Granularity = 18,
        DecimalPlacesToDisplay = 3,
        DecimalSeperator = '.'
      };

      balanceFormater.GetFormatedAmount(balanceFormaterRequest).ShouldBe("9.979");
    }

    public void Should_Prefix_Zero()
    {
      var balanceFormater = new AmountConverter();
      var balanceFormaterRequest = new FormatAmountRequest
      {
        Amount = "0123",
        Granularity = 5,
        DecimalPlacesToDisplay = 4,
        DecimalSeperator = '.'
      };
      balanceFormater.GetFormatedAmount(balanceFormaterRequest).ShouldBe("0.0012");
    }

    public void Should_Handle_Null_Amount()
    {
      var balanceFormater = new AmountConverter();
      var balanceFormaterRequest = new FormatAmountRequest
      {
        Amount = null,
        Granularity = 5,
        DecimalPlacesToDisplay = 4,
        DecimalSeperator = '.'
      };
      balanceFormater.GetFormatedAmount(balanceFormaterRequest).ShouldBe("0.0000");
    }

    public void Should_Display_Proper_Decimals_2()
    {
      var balanceFormater = new AmountConverter();
      var balanceFormaterRequest = new FormatAmountRequest
      {
        Amount = "979261128182853278",
        Granularity = 18,
        DecimalPlacesToDisplay = 3,
        DecimalSeperator = '.'
      };

      balanceFormater.GetFormatedAmount(balanceFormaterRequest).ShouldBe("0.979");
    }



    public void Should_Handle_Negative_Amount()
    {
      var balanceFormater = new AmountConverter();
      var balanceFormaterRequest = new FormatAmountRequest
      {
        Amount = "-9979261128182853278",
        Granularity = 18,
        DecimalPlacesToDisplay = 4,
        DecimalSeperator = '.'
      };
      balanceFormater.GetFormatedAmount(balanceFormaterRequest).ShouldBe("-9.9792");
    }

    public void Should_Handle_Negative_Decimal_Amount()
    {
      var balanceFormater = new AmountConverter();
      var balanceFormaterRequest = new FormatAmountRequest
      {
        Amount = "-342344534500000000",
        Granularity = 17,
        DecimalPlacesToDisplay = 4,
        DecimalSeperator = '.'
      };

      balanceFormater.GetFormatedAmount(balanceFormaterRequest).ShouldBe("-3.4234");
    }



    public void Should_Handle_Negative_Decimal_Amount_2()
    {
      var balanceFormater = new AmountConverter();
      var balanceFormaterRequest = new FormatAmountRequest
      {
        Amount = "-342344534500000000",
        Granularity = 18,
        DecimalPlacesToDisplay = 4,
        DecimalSeperator = '.'
      };

      balanceFormater.GetFormatedAmount(balanceFormaterRequest).ShouldBe("-0.3423");
    }

  }
}