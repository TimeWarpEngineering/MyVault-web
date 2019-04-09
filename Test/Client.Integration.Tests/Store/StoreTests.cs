namespace Herc.Pwa.Client.Integration.Tests
{
  using System;
  using System.IO;
  using BlazorState;
  using BlazorState.Integration.Tests.Infrastructure;
  using Herc.Pwa.Client.Features.Application;
  using Microsoft.Extensions.DependencyInjection;
  using Shouldly;

  class StoreTests
  {
    public StoreTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Store = ServiceProvider.GetService<IStore>();
      ReduxDevToolsStore = ServiceProvider.GetService<IReduxDevToolsStore>();
      ApplicationState = Store.GetState<ApplicationState>();
    }

    private ApplicationState ApplicationState { get; set; }

    private IServiceProvider ServiceProvider { get; }
    private IStore Store { get; }
    private IReduxDevToolsStore ReduxDevToolsStore { get; }

    public void ShouldLoadStatesFromJson()
    {
      //Arrange
      string jsonString = File.ReadAllText("./Store/Store.json");
      //Act
      ReduxDevToolsStore.LoadStatesFromJson(jsonString);
      // Assert
      ApplicationState applicationState = Store.GetState<ApplicationState>();
      applicationState.Name.ShouldBe("Blazor State Demo Application");
      applicationState.Guid.ToString().ShouldBe("5a2efcec-6297-4254-a2dc-30e4e567e549");

    }
  }
}
