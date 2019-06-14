namespace Server
{
  using System.Reflection;
  using AutoMapper;
  using Server.Data;
  using BlazorState;
  using MediatR;
  using Microsoft.AspNetCore.Builder;
  using Microsoft.AspNetCore.Hosting;
  using Microsoft.EntityFrameworkCore;
  using Microsoft.Extensions.Configuration;
  using Microsoft.AspNetCore.ResponseCompression;
  using Microsoft.Extensions.DependencyInjection;
  using Microsoft.Extensions.Hosting;
  using System.Linq;
  using Shared.Features.Conversion;
  using FluentValidation;
  using Server.Services.AnthemGold.Price;
  using Server.Services.AnthemGold;
  using Server.Services.CryptoCompare.SingleSymbolPrice;
  using Server.Services.CryptoCompare;

  public class Startup
  {
    public Startup(IConfiguration aConfiguration)
    {
      Configuration = aConfiguration;
    }

    public IConfiguration Configuration { get; }
   
    public void Configure(IApplicationBuilder aApplicationBuilder, IWebHostEnvironment aWebHostEnvironment)
    {
      aApplicationBuilder.UseHttpsRedirection();
      aApplicationBuilder.UseResponseCompression();

      if (aWebHostEnvironment.IsDevelopment())
      {
        aApplicationBuilder.UseDeveloperExceptionPage();
        aApplicationBuilder.UseBlazorDebugging();
      }
      aApplicationBuilder.UseClientSideBlazorFiles<Client.Startup>();

      aApplicationBuilder.UseRouting();
      aApplicationBuilder.UseEndpoints(aEndpointRouteBuilder =>
      {
        aEndpointRouteBuilder.MapControllers(); // We use explicit attribute routing so dont need MapDefaultControllerRoute
        aEndpointRouteBuilder.MapBlazorHub();
        aEndpointRouteBuilder.MapFallbackToClientSideBlazor<Client.Startup>("/_Host");
      });
    }

    public void ConfigureServices(IServiceCollection aServiceCollection)
    {
      aServiceCollection.AddCors(aCorsOptions =>
      {
        aCorsOptions.AddPolicy("any",
            aCorsPolicyBuilder => aCorsPolicyBuilder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
			 });
	  aServiceCollection.AddRazorPages();
	  

      var assemblies = new Assembly[] { typeof(Startup).Assembly };
      aServiceCollection.AddAutoMapper(assemblies);
	  aServiceCollection.AddServerSideBlazor();

      string connectionString = Configuration.GetConnectionString(nameof(AnthemGoldPwaDbContext));
      aServiceCollection.AddDbContext<AnthemGoldPwaDbContext>(options =>
        options.UseSqlServer(connectionString)
      );

      aServiceCollection.AddMvc()
        .AddNewtonsoftJson();

      aServiceCollection.AddResponseCompression(opts =>
      {
        opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                  new[] { "application/octet-stream" });
      });

      aServiceCollection.AddBlazorState((a) => a.Assemblies =
       new Assembly[] {
         typeof(Startup).GetTypeInfo().Assembly,
         typeof(Client.Startup).GetTypeInfo().Assembly
       }
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