namespace Client
{
  using Blazor.Extensions.Logging;
  using BlazorHostedCSharp.Client.Features.ClientLoader;
  using BlazorState;
  using BlazorState.Services;
  using BlazorStyled;
  using Client.Components.Shared;
  using Client.Features.Application;
  using Client.Features.Edge;
  using Client.Features.Edge.EdgeAccount;
  using Client.Features.Rate;
  using Client.Services;
  using FluentValidation;
  using Microsoft.AspNetCore.Components.Builder;
  using Microsoft.Extensions.DependencyInjection;
  using Microsoft.Extensions.Logging;
  using Nethereum.Util;
  using Shared.Features.Conversion;
  using System.Reflection;
  using static Client.Features.Edge.EdgeCurrencyWalletsState;

  public class Startup
  {
    public void Configure(IComponentsApplicationBuilder aComponentsApplicationBuilder) =>
      aComponentsApplicationBuilder.AddComponent<App>("app");

    public void ConfigureServices(IServiceCollection aServiceCollection)
    {
      aServiceCollection.AddBlazorState
      (
        (aOptions) =>
          {
            aOptions.UseReduxDevToolsBehavior = false;
            aOptions.Assemblies =
              new Assembly[]
              {
                typeof(Startup).GetTypeInfo().Assembly,
              };
          }
      );
      aServiceCollection.AddBlazorStyled();
      if (new BlazorHostingLocation().IsClientSide)
      {
        aServiceCollection.AddLogging(aLoggingBuilder => aLoggingBuilder
            .AddBrowserConsole()
            .SetMinimumLevel(LogLevel.Trace));
      };
      aServiceCollection.AddSingleton<ColorPalette>();
      aServiceCollection.AddSingleton<AmountConverter>();
      aServiceCollection.AddScoped<IValidator<ConversionRequest>, ConversionRequestValidator>();
      aServiceCollection.AddSingleton<AddressUtil>();
      aServiceCollection.AddScoped<IValidator<SendAction>, SendValidator>();
      aServiceCollection.AddScoped<ClientLoader>();
      aServiceCollection.AddScoped<IClientLoaderConfiguration, ClientLoaderConfiguration>();
      aServiceCollection.AddTransient<ApplicationState>();
      aServiceCollection.AddTransient<EdgeState>();
      aServiceCollection.AddTransient<EdgeAccountState>();
      aServiceCollection.AddTransient<EdgeCurrencyWalletsState>();
      aServiceCollection.AddTransient<RateState>();
      aServiceCollection.AddTransient<WalletState>();
    }
  }
}