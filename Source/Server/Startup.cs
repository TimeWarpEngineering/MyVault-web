namespace Server
{
  using AutoMapper;
  using FluentValidation;
  using MediatR;
  using Microsoft.AspNetCore.Builder;
  using Microsoft.AspNetCore.Hosting;
  using Microsoft.AspNetCore.ResponseCompression;
  using Microsoft.EntityFrameworkCore;
  using Microsoft.Extensions.Configuration;
  using Microsoft.Extensions.DependencyInjection;
  using Microsoft.Extensions.Hosting;
  using Server.Data;
  using Server.Services.AnthemGold;
  using Server.Services.AnthemGold.Price;
  using Server.Services.CryptoCompare;
  using Server.Services.CryptoCompare.SingleSymbolPrice;
  using Shared.Features.Conversion;
  using System.Linq;
  using System.Reflection;

  public class Startup
  {
    public Startup(IConfiguration aConfiguration)
    {
      Configuration = aConfiguration;
    }

    public IConfiguration Configuration { get; }

    public void Configure
    (
      IApplicationBuilder aApplicationBuilder, 
      IWebHostEnvironment aWebHostEnvironment
    )
    {
      aApplicationBuilder.UseHttpsRedirection();
      aApplicationBuilder.UseResponseCompression();

      if (aWebHostEnvironment.IsDevelopment())
      {
        aApplicationBuilder.UseDeveloperExceptionPage();
        aApplicationBuilder.UseBlazorDebugging();
      }

      aApplicationBuilder.UseRouting();
      aApplicationBuilder.UseEndpoints
      (
        aEndpointRouteBuilder =>
        {
          // We use explicit attribute routing so we do not need MapDefaultControllerRoute
          aEndpointRouteBuilder.MapControllers(); 
          aEndpointRouteBuilder.MapBlazorHub();
          aEndpointRouteBuilder.MapFallbackToPage("/_Host");
        }
      );
      aApplicationBuilder.UseClientSideBlazorFiles<Client.Startup>();
    }

    public void ConfigureServices(IServiceCollection aServiceCollection)
    {
      aServiceCollection.AddRazorPages();

      var assemblies = new Assembly[] { typeof(Startup).Assembly };
      aServiceCollection.AddAutoMapper(assemblies);
      aServiceCollection
        .AddServerSideBlazor()
        .AddCircuitOptions(options => { options.DetailedErrors = true; })
        .AddHubOptions(aHubOptions => aHubOptions.MaximumReceiveMessageSize = 102400000);

      string connectionString = Configuration.GetConnectionString(nameof(AnthemGoldPwaDbContext));
      aServiceCollection.AddDbContext<AnthemGoldPwaDbContext>
      (
        aOptions => aOptions.UseSqlServer(connectionString)
      );

      aServiceCollection.AddMvc();

      aServiceCollection.AddResponseCompression
      (
        aResponseCompressionOptions =>
          aResponseCompressionOptions.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat
          (
            new[] { "application/octet-stream" }
          )

      );

      //aServiceCollection.AddSingleton<HttpClient>();
      // TODO: when FluentValidation updated for dotnet core 3 we can use AddFluentValidation and it will scan for validators.
      // Until then we register them manually.
      aServiceCollection.AddScoped<IValidator<ConversionRequest>, ConversionRequestValidator>();
      aServiceCollection.AddScoped<IValidator<PriceRequest>, PriceRequestValidator>();
      aServiceCollection.AddScoped<IValidator<SingleSymbolPriceRequest>, SingleSymbolPriceRequestValidator>();

      new Client.Startup().ConfigureServices(aServiceCollection);

      aServiceCollection.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
      aServiceCollection.AddScoped<AnthemGoldHttpClient>();
      aServiceCollection.AddScoped<CryptoCompareHttpClient>();
      //aServiceCollection.Scan(aTypeSourceSelector => aTypeSourceSelector
      //  .FromAssemblyOf<Startup>()
      //  .AddClasses()
      //  .AsSelf()
      //  .WithScopedLifetime());
    }
  }
}