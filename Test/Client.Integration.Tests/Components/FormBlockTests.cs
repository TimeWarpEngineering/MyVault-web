using System;
using BlazorState;
using BlazorState.Integration.Tests.Infrastructure;
using Herc.Pwa.Client.Components;
using Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet;
using Herc.Pwa.Client.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace Herc.Pwa.Client.Integration.Tests.Components
{
  public class FormBlockTestsSkip
  {
    public FormBlockTestsSkip(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
      Store = ServiceProvider.GetService<IStore>();
      BalanceFormater = ServiceProvider.GetService<AmountConverter>();
      EdgeCurrencyWalletsState = Store.GetState<EdgeCurrencyWalletsState>();
    }

    private EdgeCurrencyWalletsState EdgeCurrencyWalletsState { get; set; }
    private IMediator Mediator { get; }
    private IServiceProvider ServiceProvider { get; }
    private IStore Store { get; }
    private AmountConverter BalanceFormater { get; }

    public void SkipShould()
    {
      var block = new FormBlock<SampleClass>()
      {
        Expression = (aSampleClass) => aSampleClass.MyProperty
      };
      block.Label.ShouldBe(nameof(SampleClass.MyProperty));
    }

    public class SampleClass
    {
      public int MyProperty { get; set; }
    }
  }
}