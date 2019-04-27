namespace Server
{
  using System;
  using Server.Data;
  using Microsoft.AspNetCore;
  using Microsoft.AspNetCore.Hosting;
  using Microsoft.Extensions.Configuration;
  using Microsoft.Extensions.DependencyInjection;
  using Microsoft.Extensions.Logging;
  using Microsoft.Extensions.Hosting;

  public class Program
  {
    public static IWebHost BuildWebHost(string[] aArgumentArray) =>
          WebHost
            .CreateDefaultBuilder(aArgumentArray)
            .UseConfiguration(new ConfigurationBuilder()
              .AddCommandLine(aArgumentArray)
              .Build())
            .UseStartup<Startup>()
            .Build();


    public static void Main(string[] aArgumentArray)
    {
      IWebHost host = BuildWebHost(aArgumentArray);

      //using (IServiceScope scope = host.Services.CreateScope())
      //{
      //  System.IServiceProvider services = scope.ServiceProvider;
      //  try
      //  {
      //    AnthemGoldPwaDbContext anthemGoldPwaDbContext = services.GetRequiredService<AnthemGoldPwaDbContext>();
      //    DbInitializer.Initialize(anthemGoldPwaDbContext);
      //  }
      //  catch (Exception exception)
      //  {
      //    ILogger<Program> logger = services.GetRequiredService<ILogger<Program>>();
      //    logger.LogError(exception, "An error occurred creating the DB.");
      //  }
      //}
      host.Run();
    }
  }
}