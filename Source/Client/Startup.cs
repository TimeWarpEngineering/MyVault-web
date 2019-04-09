namespace Client
{
  //using Blazor.Extensions.Logging;
  using BlazorState;
  using FluentValidation;
  using Client.Features.Edge.EdgeCurrencyWallet;
  using Client.Services;
  using Microsoft.AspNetCore.Components.Builder;
  using Microsoft.Extensions.DependencyInjection;
  using Nethereum.Util;
  using Client.Components.Shared;

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