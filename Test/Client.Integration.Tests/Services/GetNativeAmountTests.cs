using FluentValidation;
using Herc.Pwa.Client.Services;
using Shouldly;

namespace Herc.Pwa.Client.Integration.Tests.Services
{
  public class GetNaitveAmountTests
  {
    public void Should_Convert()
    {
      var balanceFormater = new AmountConverter();
      var getNativeAmountRequest = new GetNativeAmountRequest
      {
        Amount = "0.02",
        Granularity = 18,
        DecimalSeperator = '.'
      };

      balanceFormater.GetNativeAmount(getNativeAmountRequest).ShouldBe("20000000000000000");
    }

    public void Should_Convert_From_ETH_Wei_With_Only_Integer_Portion()
    {
      var balanceFormater = new AmountConverter();
      var getNativeAmountRequest = new GetNativeAmountRequest
      {
        Amount = "1",
        Granularity = 18,
        DecimalSeperator = '.'
      };

      balanceFormater.GetNativeAmount(getNativeAmountRequest).ShouldBe("1000000000000000000");
    }

    public void Should_Convert_From_ETH_Wei_With_Only_Decimal_Portion()
    {
      var balanceFormater = new AmountConverter();
      var getNativeAmountRequest = new GetNativeAmountRequest
      {
        Amount = ".1",
        Granularity = 18,
        DecimalSeperator = '.'
      };

      balanceFormater.GetNativeAmount(getNativeAmountRequest).ShouldBe("100000000000000000");
    }

    public void Should_Convert_With_Only_Decimal_Portion_And_Leading_Zeros()
    {
      var balanceFormater = new AmountConverter();
      var getNativeAmountRequest = new GetNativeAmountRequest
      {
        Amount = ".0001",
        Granularity = 18,
        DecimalSeperator = '.'
      };

      balanceFormater.GetNativeAmount(getNativeAmountRequest).ShouldBe("100000000000000");
    }

    public void Should_Convert_Minimum_Of_One_Wei()
    {
      var balanceFormater = new AmountConverter();
      var getNativeAmountRequest = new GetNativeAmountRequest
      {
        Amount = "0.000000000000000001",
        Granularity = 18,
        DecimalSeperator = '.'
      };

      balanceFormater.GetNativeAmount(getNativeAmountRequest).ShouldBe("1");
    }

    public void Should_Convert_With_Both_Peices()
    {
      var balanceFormater = new AmountConverter();
      var getNativeAmountRequest = new GetNativeAmountRequest
      {
        Amount = "1000.0001",
        Granularity = 18,
        DecimalSeperator = '.'
      };

      balanceFormater.GetNativeAmount(getNativeAmountRequest).ShouldBe("1000000100000000000000");
    }

    public void Should_Truncate_If_Below_Granularity()
    {
      var balanceFormater = new AmountConverter();
      var getNativeAmountRequest = new GetNativeAmountRequest
      {
        Amount = "0.0000000000000000001",
        Granularity = 18,
        DecimalSeperator = '.'
      };

      balanceFormater.GetNativeAmount(getNativeAmountRequest).ShouldBe("0");
    }

    public void Should_Truncate_Decimal_If_Below_Granularity()
    {
      var balanceFormater = new AmountConverter();
      var getNativeAmountRequest = new GetNativeAmountRequest
      {
        Amount = "1000.0000000000000000001",
        Granularity = 18,
        DecimalSeperator = '.'
      };

      balanceFormater.GetNativeAmount(getNativeAmountRequest).ShouldBe("1000000000000000000000");
    }


    public void Should_Work_With_Trailing_Zeros()
    {
      var balanceFormater = new AmountConverter();
      var getNativeAmountRequest = new GetNativeAmountRequest
      {
        Amount = "0.1000000",
        Granularity = 18,
        DecimalSeperator = '.'
      };

      balanceFormater.GetNativeAmount(getNativeAmountRequest).ShouldBe("100000000000000000");
    }

    public void Should_Work_With_All_Zeros()
    {
      var balanceFormater = new AmountConverter();
      var getNativeAmountRequest = new GetNativeAmountRequest
      {
        Amount = "0000.000000",
        Granularity = 18,
        DecimalSeperator = '.'
      };

      balanceFormater.GetNativeAmount(getNativeAmountRequest).ShouldBe("0");
    }

    public void Should_Throw_If_Not_Numeric()
    {
      var balanceFormater = new AmountConverter();
      var getNativeAmountRequest = new GetNativeAmountRequest
      {
        Amount = "A",
        Granularity = 18,
        DecimalSeperator = '.'
      };

      Should.Throw<ValidationException>(() => balanceFormater.GetNativeAmount(getNativeAmountRequest));
    }

    public void Should_Throw_If_Granularity_Negative()
    {
      var balanceFormater = new AmountConverter();
      var getNativeAmountRequest = new GetNativeAmountRequest
      {
        Amount = "0000.000000",
        Granularity = -18,
        DecimalSeperator = '.'
      };
      Should.Throw<ValidationException>(() => balanceFormater.GetNativeAmount(getNativeAmountRequest));
      ;
    }

    public void Should_Throw_If_DecimalSeperator_Default()
    {
      var balanceFormater = new AmountConverter();
      var getNativeAmountRequest = new GetNativeAmountRequest
      {
        Amount = "0000.000000",
        Granularity = 18,
        DecimalSeperator = '\0'
      };
      Should.Throw<ValidationException>(() => balanceFormater.GetNativeAmount(getNativeAmountRequest));
      ;
    }
    
  }
}