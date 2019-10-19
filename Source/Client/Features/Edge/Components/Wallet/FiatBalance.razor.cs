#nullable enable
namespace Client.Features.Edge.Components.Wallet
{
  using Client.Components;
  using Client.Features.Edge;
  using Client.Features.Rate;
  using Client.Services;
  using Microsoft.AspNetCore.Components;
  using System;
  using System.Linq;
  using System.Threading.Tasks;
  using static Client.Features.Rate.RateState;

  public class FiatBalanceBase : BaseComponent
  {
    public decimal Balance => decimal.Parse(FormattedBalanceForConversion);

    public string? BalanceInFiat => (Rate * Balance)?.ToString("0.##");

    public string CurrencyCode => SelectedEdgeCurrencyWallet.SelectedCurrencyCode;

    public string ShortFiatCurrencyCode => SelectedEdgeCurrencyWallet.ShortFiatCurrencyCode;

    //Math.Round(Shared.Features.Conversion.ConversionResponse.Rate* Decimal.Parse(FormattedBalanceForConversion), 2)
    public int Granularity => SelectedEdgeCurrencyWallet.Granularity[CurrencyCode];

    public decimal? Rate => RateState.Conversions.FirstOrDefault(c => c.FromCurrency == CurrencyCode && c.ToCurrency == ShortFiatCurrencyCode)?.Rate;

    private EdgeCurrencyWallet SelectedEdgeCurrencyWallet => EdgeCurrencyWalletsState.SelectedEdgeCurrencyWallet;

    protected string FormattedBalanceForConversion => AmountConverter.GetFormatedAmount(
      new FormatAmountRequest { Amount = SelectedEdgeCurrencyWallet.Balances[CurrencyCode], DecimalPlacesToDisplay = Granularity, DecimalSeperator = '.', Granularity = Granularity });

    [Inject]
    private AmountConverter AmountConverter { get; set; } = default!;

    protected override async Task OnAfterRenderAsync(bool aFirstRender)
    {
      Conversion? conversion = RateState.GetConversion(CurrencyCode, ShortFiatCurrencyCode);

      if (conversion == null || conversion.TimeStamp.AddMinutes(5) < DateTime.UtcNow)
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
}