namespace BlazorState.Integration.Tests.Infrastructure
{
  using System;
  using System.Reflection;
  using Client;
  using Client.Integration.Tests.Infrastructure;
  using BlazorState;
  using Microsoft.AspNetCore.Blazor.Hosting;
  using Microsoft.Extensions.DependencyInjection;
  using Client.Services;
  using Nethereum.Util;
  using FluentValidation;
  using Client.Features.Edge;
  using static Client.Features.Edge.EdgeCurrencyWalletsState;
  using Client.Features.Rate;
  using Client.Features.Application;
  using Client.Features.Edge.EdgeAccount;

  /// <summary>
  /// A known starting state(baseline) for all tests.
  /// And Common set of functions
  /// </summary>
  public class TestFixture//: IMediatorFixture, IStoreFixture, IServiceProviderFixture
  {
    public TestFixture(BlazorStateTestServer aBlazorStateTestServer)
    {
      BlazorStateTestServer = aBlazorStateTestServer;
      IWebAssemblyHostBuilder webAssemblyHostBuilder =
        BlazorWebAssemblyHost.CreateDefaultBuilder()
          //.UseBlazorStartup<Startup>()
          .ConfigureServices(ConfigureServices);

      ServiceProvider = webAssemblyHostBuilder.Build().Services;
    }

    /// <summary>
    /// This is the ServiceProvider that will be used by the Client
    /// </summary>
    public IServiceProvider ServiceProvider { get; set; }

    private BlazorStateTestServer BlazorStateTestServer { get; }

    /// <summary>
    /// Special configuration for Testing with the Test Server
    /// </summary>
    /// <param name="aServiceCollection"></param>
    private void ConfigureServices(IServiceCollection aServiceCollection)
    {
      aServiceCollection.AddSingleton<AmountConverter>();
      aServiceCollection.AddSingleton(BlazorStateTestServer.CreateClient());
      aServiceCollection.AddSingleton<AddressUtil>();
      aServiceCollection.AddScoped(typeof(IValidator<SendAction>), typeof(SendValidator));


      aServiceCollection.AddBlazorState(aOptions => aOptions.Assemblies =
        new Assembly[] { typeof(Startup).GetTypeInfo().Assembly });

      aServiceCollection.AddTransient<ApplicationState>();
      aServiceCollection.AddTransient<EdgeState>();
      aServiceCollection.AddTransient<EdgeAccountState>();
      aServiceCollection.AddTransient<EdgeCurrencyWalletsState>();
      aServiceCollection.AddTransient<RateState>();
      aServiceCollection.AddTransient<WalletState>();
    }
  }
}