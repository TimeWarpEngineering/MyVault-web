namespace Herc.Pwa.Server.Data
{
  using System.IO;
  using System.Linq;
  using Herc.Pwa.Server.Entities;

  internal class DbInitializer
  {
    public const string ApplicationName = "Hercules Progressive Web Application";
    public const string ApplicationVersion = "1.0.0";

    public static void Initialize(HercPwaDbContext context)
    {
      context.Database.EnsureCreated();

      if (context.Application.Any())
      {
        return; // DB has already been seeded
      };

      var application = new Application
      {
        Name = ApplicationName,
        Version = ApplicationVersion
      };

      context.Application.Add(application);

      //var assetDefinition = new AssetDefinition
      //{
      //  Name = "AnthemGold",
      //  Url = "https://anthembunker.com",
      //  Logo = File.ReadAllBytes(@"Data\SampleLogos\AG_logo.png"),
      //};

      //var metrics = new Metric[]
      //{
      //  new Metric { Name = "Assay", Default = "0.9999", UnitOfMeasure = "Fineness", Description="A Bar of Gold", SampleValue="0.9999", Regex= @"^0([.,])\d+" },
      //  new Metric { Name = "Bar Serial #", Description="The serial number of the bar of gold", SampleValue="123456", UnitOfMeasure="Identifier" }
      //};
      //assetDefinition.Metrics.AddRange(metrics);

      //context.AssetDefinitions.Add(assetDefinition);
      context.SaveChanges();

    }
  }
}
