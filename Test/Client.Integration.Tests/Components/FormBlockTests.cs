namespace Client.Integration.Tests.Components
{
  using System;
  using BlazorState;
  using BlazorState.Integration.Tests.Infrastructure;
  using Client.Components;
  using Client.Features.Edge;
  using Client.Services;
  using MediatR;
  using Microsoft.Extensions.DependencyInjection;
  using Shouldly;

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