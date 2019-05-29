namespace Client.Features.Edge.Components.Wallet
{
  using Client.Components;
  using Client.Features.Edge.EdgeCurrencyWallet;
  using Client.Features.Rate;
  using Client.Services;
  using Microsoft.AspNetCore.Components;
  using System;
  using System.Linq;
  using System.Threading.Tasks;

  public class FiatBalanceBase : BaseComponent
  {
    public decimal Balance => decimal.Parse(FormattedBalanceForConversion);

    public decimal BalanceInFiat => Rate * Balance;

    public string CurrencyCode => SelectedEdgeCurrencyWallet.SelectedCurrencyCode;

    public string ShortFiatCurrencyCode => SelectedEdgeCurrencyWallet.ShortFiatCurrencyCode;

    //Math.Round(Shared.Features.Conversion.ConversionResponse.Rate* Decimal.Parse(FormattedBalanceForConversion), 2)
    public int Granularity => SelectedEdgeCurrencyWallet.Granularity[CurrencyCode];

    public decimal Rate => RateState.Rate;

    private EdgeCurrencyWallet SelectedEdgeCurrencyWallet => EdgeCurrencyWalletsState.SelectedEdgeCurrencyWallet;

    protected string FormattedBalanceForConversion => AmountConverter.GetFormatedAmount(
      new FormatAmountRequest { Amount = SelectedEdgeCurrencyWallet.Balances[CurrencyCode], DecimalPlacesToDisplay = 2, DecimalSeperator = '.', Granularity = Granularity });

    [Inject]
    private AmountConverter AmountConverter { get; set; }

    protected override async Task OnInitAsync()
    {
      var getRateAction = new GetRateAction
      {
        ToCurrency = ShortFiatCurrencyCode,
        FromCurrency = CurrencyCode
      };
      _ = await Mediator.Send(getRateAction);
    }
  }
}