namespace Client.Features.Edge
{
  using Client.Components;
  using Client.Pages;
  using Client.Services;
  using FluentValidation;
  using FluentValidation.Results;
  using Microsoft.AspNetCore.Components;
  using Shared;
  using Shared.Enumerations.FeeOption;
  using System;
  using System.Linq;
  using System.Net;
  using System.Threading.Tasks;
  using static BlazorState.Features.Routing.RouteState;
  using static Client.Features.Edge.EdgeCurrencyWalletsState;

  public class WalletSendFormBase : BaseComponent
  {
    private readonly Lazy<FormDataClass> LazyFormData;

    public WalletSendFormBase()
    {
      LazyFormData = new Lazy<FormDataClass>(() => new FormDataClass(AmountConverter, this));
    }

    [Inject] private AmountConverter AmountConverter { get; set; }
    private string EdgeCurrencyWalletId => WebUtility.UrlDecode(EdgeCurrencyWalletEncodedId);
    protected FormDataClass FormData => LazyFormData.Value;
    protected FormValidatorClass FormValidator => new FormValidatorClass(SendValidator);
    protected string MaxAmount => AmountConverter.GetFormatedAmount(new FormatAmountRequest { Amount = Balance, DecimalPlacesToDisplay = Granularity, DecimalSeperator = '.', Granularity = 18 });
    protected string Pattern => RegularExpressions.FloatingPointNumberNoSign('.');
    protected ValidationResult ValidationResult { get; set; }
    protected string WalletName => EdgeCurrencyWallet.Name;
    protected string Balance => string.IsNullOrEmpty(FormData.SendAction.CurrencyCode) ? "" : EdgeCurrencyWallet.Balances[FormData.SendAction.CurrencyCode];
    protected EdgeCurrencyWallet EdgeCurrencyWallet => EdgeCurrencyWalletsState.EdgeCurrencyWallets[EdgeCurrencyWalletId];
    [Parameter] public string EdgeCurrencyWalletEncodedId { get; set; }
    protected int Granularity => EdgeCurrencyWallet.Granularity[FormData.SendAction.CurrencyCode];
    [Inject] public IValidator<SendAction> SendValidator { get; set; }

    protected override void OnInitialized()
    {
      if (EdgeCurrencyWallet.Balances.Keys.Any())
      {
        FormData.SendAction.CurrencyCode = EdgeCurrencyWallet.Balances.Keys.First();
      }
      FormData.SendAction.Fee = FeeOption.Standard;
      FormData.SendAction.EdgeCurrencyWalletId = EdgeCurrencyWalletId;
    }

    protected async Task Send()
    {
      ValidationResult = FormValidator.Validate(FormData);

      if (ValidationResult.IsValid)
      {
        await Mediator.Send(FormData.SendAction);

        await Mediator.Send(new ChangeRouteAction { NewRoute = WalletPageBase.Route });
      }
    }

    protected class FormDataClass
    {
      private string _Amount;

      public FormDataClass(AmountConverter aAmountConverter, WalletSendFormBase aWalletSendFormBase)
      {
        _Amount = "";
        SendAction = new SendAction();
        AmountConverter = aAmountConverter;
        WalletSendFormBase = aWalletSendFormBase;
      }

      private AmountConverter AmountConverter { get; }
      private WalletSendFormBase WalletSendFormBase { get; }

      public string Amount { get => _Amount; set { _Amount = value; OnAmountChange(); } }

      public SendAction SendAction { get; set; }

      protected void OnAmountChange()
      {
        var getNativeAmountRequest = new GetNativeAmountRequest
        {
          Amount = Amount,
          DecimalSeperator = '.',
          Granularity = WalletSendFormBase.Granularity
        };
        SendAction.NativeAmount = AmountConverter.GetNativeAmount(getNativeAmountRequest);
      }
    }

    protected class FormValidatorClass : AbstractValidator<FormDataClass>
    {
      public FormValidatorClass(IValidator<SendAction> aSendActionValidator)
      {
        RuleFor(aForm => aForm.Amount)
          .NotEmpty();
        RuleFor(aForm => aForm.SendAction.DestinationAddress)
          .NotEmpty()
          .WithName("Destination Address");
        RuleFor(aForm => aForm.SendAction)
          .SetValidator(aSendActionValidator)
          .When(aForm => !string.IsNullOrEmpty(aForm.Amount))
          .When(aForm => !string.IsNullOrEmpty(aForm.SendAction.DestinationAddress));
      }
    }
  }
}