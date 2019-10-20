namespace Client.Integration.Tests
{
  using BlazorState;
  using BlazorState.Integration.Tests.Infrastructure;
  using Client.Features.Application;
  using Microsoft.Extensions.DependencyInjection;
  using Shouldly;
  using System;
  using System.IO;

  internal class StoreTests
  {
    private readonly IReduxDevToolsStore ReduxDevToolsStore;

    private readonly IServiceProvider ServiceProvider;

    private readonly IStore Store;

    public StoreTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Store = ServiceProvider.GetService<IStore>();
      ReduxDevToolsStore = ServiceProvider.GetService<IReduxDevToolsStore>();
    }


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