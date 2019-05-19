namespace Client.Features.Edge.Components.Wallet
{
  using Client.Components;
  using Client.Features.Rate;
  using Client.Features.Edge.EdgeCurrencyWallet;
  using Client.Services;
  using Microsoft.AspNetCore.Components;
  using System;
  using System.Linq;
  using System.Threading.Tasks;

  public class FiatBalanceBase : BaseComponent
  {
    [Inject]
    AmountConverter AmountConverter { get; set; }

    private EdgeCurrencyWallet SelectedEdgeCurrencyWallet => EdgeCurrencyWalletsState.SelectedEdgeCurrencyWallet;
    public string FiatCurrencyCode => SelectedEdgeCurrencyWallet.FiatCurrencyCode.Split(':').Last();

    public decimal Rate => RateState.Rate;

    //Math.Round(Shared.Features.Conversion.ConversionResponse.Rate* Decimal.Parse(FormattedBalanceForConversion), 2)
    public int Granularity => SelectedEdgeCurrencyWallet.Granularity[CurrencyCode];

    public decimal BalanceInFiat => Rate * Balance;

    public decimal Balance => decimal.Parse(FormattedBalanceForConversion);
    public string CurrencyCode => SelectedEdgeCurrencyWallet.SelectedCurrencyCode;
    protected string FormattedBalanceForConversion => AmountConverter.GetFormatedAmount(
      new FormatAmountRequest { Amount = SelectedEdgeCurrencyWallet.Balances[CurrencyCode], DecimalPlacesToDisplay = 2, DecimalSeperator = '.', Granularity = Granularity });

    protected override async Task OnInitAsync()
    {
      var getRateAction = new GetRateAction
      {
        ToCurrency = FiatCurrencyCode,
        FromCurrency = CurrencyCode
      };
      RateState result =  await Mediator.Send(getRateAction);
      Console.WriteLine($"{result.Rate}, {RateState.Rate} should be same");
    }

  }
}