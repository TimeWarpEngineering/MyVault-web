namespace Client
{
  using Blazor.Extensions.Logging;
  using BlazorState;
  using BlazorState.Services;
  using FluentValidation;
  using Client.Services;
  using Client.Components.Shared;
  using Client.Features.Edge.EdgeCurrencyWallet;
  using Microsoft.AspNetCore.Components.Builder;
  using Microsoft.Extensions.DependencyInjection;
  using Nethereum.Util;
  using Shared.Features.Conversion;
  using BlazorHostedCSharp.Client.Features.ClientLoader;
  using MediatR;
  using Microsoft.Extensions.Logging;

  public class Startup
  {
    public void Configure(IComponentsApplicationBuilder aComponentsApplicationBuilder) =>
      aComponentsApplicationBuilder.AddComponent<App>("app");

    public void ConfigureServices(IServiceCollection aServiceCollection)
    {
      if (new BlazorHostingLocation().IsClientSide)
      {
        aServiceCollection.AddLogging(aLoggingBuilder => aLoggingBuilder
            .AddBrowserConsole()
            .SetMinimumLevel(LogLevel.Trace));
      };
      aServiceCollection.AddSingleton<ColorPalette>();
      aServiceCollection.AddSingleton<AmountConverter>();
      //aServiceCollection.AddScoped<IValidator<ConversionRequest>, ConversionRequestValidator>();
      aServiceCollection.AddSingleton<AddressUtil>();
      aServiceCollection.AddScoped(typeof(IValidator<SendAction>), typeof(SendValidator));
      aServiceCollection.AddBlazorState();
      aServiceCollection.AddScoped<ClientLoader>();
      aServiceCollection.AddScoped<IClientLoaderConfiguration, ClientLoaderConfiguration>();
    }
  }
}