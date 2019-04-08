namespace Herc.Pwa.Client.Services
{
  using System;
  using System.Linq;
  using FluentValidation;

  public class AmountConverter
  {
    public string GetFormatedAmount(FormatAmountRequest aFormatAmountRequest)
    {
      string balance = aFormatAmountRequest.Amount ?? "0";
      int granularity = aFormatAmountRequest.Granularity;
      int decimalPlacesToDisplay = aFormatAmountRequest.DecimalPlacesToDisplay;
      char decimalSeperator = aFormatAmountRequest.DecimalSeperator;
      bool isNegative = balance.Substring(0, 1) == "-";
      if (isNegative)
      {
        balance = balance.Remove(0,1);
      }

      string result = balance.PadLeft(granularity, '0');
      result = result.Insert(result.Length - granularity, decimalSeperator.ToString());
      result = result.Substring(0, result.Length - granularity + decimalPlacesToDisplay);

      if (result.First() == decimalSeperator)
      {
        result = $"0{result}";
      }
      if (isNegative)
      {
        result = $"-{result}";
      }
      return result;
    }

    public string GetNativeAmount(GetNativeAmountRequest aGetNativeAmountRequest)
    {
      var getNativeAmountRequestValidator = new GetNativeAmountRequestValidator();
      getNativeAmountRequestValidator.ValidateAndThrow(aGetNativeAmountRequest);

      string[] splitAmount = aGetNativeAmountRequest.Amount.Split(aGetNativeAmountRequest.DecimalSeperator);
      string decimalsplit = splitAmount.Length > 1 ? splitAmount[1] : "0";
      decimalsplit = decimalsplit.PadRight(aGetNativeAmountRequest.Granularity, '0').Substring(0, aGetNativeAmountRequest.Granularity);
      string result = $"{splitAmount[0]}{decimalsplit}";
      result = result.TrimStart(new char[] { '0' });
      result = result == "" ? "0" : result;
      Console.WriteLine($"result: {result}");
      return result;
    }
  }
}
