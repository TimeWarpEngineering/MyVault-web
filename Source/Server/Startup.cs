namespace Server
{
  using System.Reflection;
  using AutoMapper;
  using Server.Data;
  using MediatR;
  using Microsoft.AspNetCore.Builder;
  using Microsoft.AspNetCore.Hosting;
  using Microsoft.EntityFrameworkCore;
  using Microsoft.Extensions.Configuration;
  using Microsoft.Extensions.DependencyInjection;
  using Newtonsoft.Json.Serialization;

  public class Startup
  {
    public Startup(IConfiguration aConfiguration)
    {
      Configuration = aConfiguration;
    }

    public IConfiguration Configuration { get; }

    public void Configure(IApplicationBuilder aApplicationBuilder, IHostingEnvironment aHostingEnvironment)
    {
      aApplicationBuilder.UseHttpsRedirection();
      aApplicationBuilder.UseStaticFiles();
      aApplicationBuilder.UseResponseCompression();

      if (aHostingEnvironment.IsDevelopment())
      {
        aApplicationBuilder.UseDeveloperExceptionPage();
      }

      aApplicationBuilder.UseMvc();
      aApplicationBuilder.UseBlazorDualMode<Client.Startup>();

      aApplicationBuilder.UseBlazorDebugging();
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

      var assemblies = new Assembly[] { typeof(Startup).Assembly };
      aServiceCollection.AddAutoMapper(assemblies);

      string connectionString = Configuration.GetConnectionString(nameof(AnthemGoldPwaDbContext));
      aServiceCollection.AddDbContext<AnthemGoldPwaDbContext>(options =>
        options.UseSqlServer(connectionString)
      );

      aServiceCollection.AddMvc()
        .AddNewtonsoftJson(aOptions =>
           aOptions.SerializerSettings.ContractResolver =
              new DefaultContractResolver());

      aServiceCollection.AddRazorComponents<Client.Startup>();

      aServiceCollection.AddResponseCompression();
      aServiceCollection.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
      aServiceCollection.Scan(aTypeSourceSelector => aTypeSourceSelector
        .FromAssemblyOf<Startup>()
        .AddClasses()
        .AsSelf()
        .WithScopedLifetime());
    }
  }
}