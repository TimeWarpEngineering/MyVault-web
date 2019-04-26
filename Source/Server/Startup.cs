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
  using Newtonsoft.Json.Serialization;
  using System.Linq;

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
      //aApplicationBuilder.UseStaticFiles();
      aApplicationBuilder.UseResponseCompression();

      if (aWebHostEnvironment.IsDevelopment())
      {
        aApplicationBuilder.UseDeveloperExceptionPage();
        aApplicationBuilder.UseBlazorDebugging();
      }

      aApplicationBuilder.UseRouting();
      aApplicationBuilder.UseEndpoints(aEndpointRouteBuilder =>
      {
        aEndpointRouteBuilder.MapControllers(); // We use explicit attribute routing so dont need MapDefaultControllerRoute
        aEndpointRouteBuilder.MapBlazorHub();
        aEndpointRouteBuilder.MapFallbackToPage("/_Host");
      });
      aApplicationBuilder.UseBlazor<Client.Startup>();
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
        .AddNewtonsoftJson(aOptions =>
           aOptions.SerializerSettings.ContractResolver =
              new DefaultContractResolver());

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
      new Client.Startup().ConfigureServices(aServiceCollection);

      aServiceCollection.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
      aServiceCollection.Scan(aTypeSourceSelector => aTypeSourceSelector
        .FromAssemblyOf<Startup>()
        .AddClasses()
        .AsSelf()
        .WithScopedLifetime());
    }
  }
}