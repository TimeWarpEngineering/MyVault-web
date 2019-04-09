namespace Herc.Pwa.Client
{
  //using Blazor.Extensions.Logging;
  using BlazorState;
  using FluentValidation;
  using Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet;
  using Herc.Pwa.Client.Services;
  using Herc.Pwa.Client.Shared;
  using Microsoft.AspNetCore.Components.Builder;
  using Microsoft.Extensions.DependencyInjection;
  using Microsoft.Extensions.Logging;
  using Nethereum.Util;

  public class Startup
  {
    public void Configure(IComponentsApplicationBuilder aBlazorApplicationBuilder) =>
      aBlazorApplicationBuilder.AddComponent<App>("app");

    public void ConfigureServices(IServiceCollection aServiceCollection)
    {
      aServiceCollection.AddSingleton<ColorPalette>();
      aServiceCollection.AddSingleton<AmountConverter>();
      aServiceCollection.AddSingleton<AddressUtil>();
      aServiceCollection.AddScoped(typeof(IValidator<SendAction>), typeof(SendValidator));
      //aServiceCollection.AddLogging(aLoggingBuilder => aLoggingBuilder
      //    .AddBrowserConsole()
      //    .SetMinimumLevel(LogLevel.Trace)
      //);
      aServiceCollection.AddBlazorState();
    }
  }
}