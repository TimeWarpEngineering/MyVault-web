using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Server.Data;
using Server.Entities;
//using FakeItEasy;
using MediatR;
//using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Respawn;

namespace Server.Integration.Tests
{
  public class SliceFixture
  {
    private static readonly Checkpoint s_checkpoint;
    private static readonly IConfigurationRoot s_configuration;
    private static readonly IServiceScopeFactory s_scopeFactory;

    static SliceFixture()
    {
      IConfigurationBuilder builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile(path: "appsettings.json", optional: true, reloadOnChange: true)
        .AddEnvironmentVariables();
      s_configuration = builder.Build();

      var startup = new Startup(s_configuration);
      var services = new ServiceCollection();
      startup.ConfigureServices(services);
      ServiceProvider provider = services.BuildServiceProvider();
      s_scopeFactory = provider.GetService<IServiceScopeFactory>();
      s_checkpoint = new Checkpoint()
      {
        TablesToIgnore = new[]
        { nameof(Application) }
      };
    }

    public static Task ResetCheckpoint() => s_checkpoint.Reset(s_configuration.GetConnectionString("AnthemGoldPwaDbContext"));

    public static async Task ExecuteScopeAsync(Func<IServiceProvider, Task> action)
    {
      using (IServiceScope scope = s_scopeFactory.CreateScope())
      {
        AnthemGoldPwaDbContext dbContext = scope.ServiceProvider.GetService<AnthemGoldPwaDbContext>();

        try
        {
          await dbContext.BeginTransactionAsync().ConfigureAwait(false);

          await action(scope.ServiceProvider).ConfigureAwait(false);

          await dbContext.CommitTransactionAsync().ConfigureAwait(false);
        }
        catch (Exception)
        {
          dbContext.RollbackTransaction();
          throw;
        }
      }
    }

    public static async Task<T> ExecuteScopeAsync<T>(Func<IServiceProvider, Task<T>> action)
    {
      using (IServiceScope serviceScope = s_scopeFactory.CreateScope())
      {
        AnthemGoldPwaDbContext dbContext = serviceScope.ServiceProvider.GetService<AnthemGoldPwaDbContext>();

        try
        {
          await dbContext.BeginTransactionAsync().ConfigureAwait(false);

          T result = await action(serviceScope.ServiceProvider).ConfigureAwait(false);

          await dbContext.CommitTransactionAsync().ConfigureAwait(false);

          return result;
        }
        catch (Exception)
        {
          dbContext.RollbackTransaction();
          throw;
        }
      }
    }

    public static Task ExecuteDbContextAsync(Func<AnthemGoldPwaDbContext, Task> action)
        => ExecuteScopeAsync(sp => action(sp.GetService<AnthemGoldPwaDbContext>()));

    public static Task ExecuteDbContextAsync(Func<AnthemGoldPwaDbContext, IMediator, Task> action)
        => ExecuteScopeAsync(sp => action(sp.GetService<AnthemGoldPwaDbContext>(), sp.GetService<IMediator>()));

    public static Task<T> ExecuteDbContextAsync<T>(Func<AnthemGoldPwaDbContext, Task<T>> action)
        => ExecuteScopeAsync(sp => action(sp.GetService<AnthemGoldPwaDbContext>()));

    public static Task<T> ExecuteDbContextAsync<T>(Func<AnthemGoldPwaDbContext, IMediator, Task<T>> action)
        => ExecuteScopeAsync(sp => action(sp.GetService<AnthemGoldPwaDbContext>(), sp.GetService<IMediator>()));

    public static Task InsertAsync<T>(params T[] entities) where T : class =>
      ExecuteDbContextAsync
      (db =>
        {
          foreach (T entity in entities)
          {
            db.Set<T>().Add(entity);
          }
          return db.SaveChangesAsync();
        }
      );

    public static Task InsertAsync<TEntity>(TEntity entity) where TEntity : class =>
      ExecuteDbContextAsync
      (db =>
        {
          db.Set<TEntity>().Add(entity);

          return db.SaveChangesAsync();
        }
      );

    public static Task InsertAsync<TEntity, TEntity2>(TEntity entity, TEntity2 entity2)
        where TEntity : class
        where TEntity2 : class
    {
      return ExecuteDbContextAsync(db =>
      {
        db.Set<TEntity>().Add(entity);
        db.Set<TEntity2>().Add(entity2);

        return db.SaveChangesAsync();
      });
    }

    public static Task InsertAsync<TEntity, TEntity2, TEntity3>(TEntity entity, TEntity2 entity2, TEntity3 entity3)
        where TEntity : class
        where TEntity2 : class
        where TEntity3 : class
    {
      return ExecuteDbContextAsync(db =>
      {
        db.Set<TEntity>().Add(entity);
        db.Set<TEntity2>().Add(entity2);
        db.Set<TEntity3>().Add(entity3);

        return db.SaveChangesAsync();
      });
    }

    public static Task InsertAsync<TEntity, TEntity2, TEntity3, TEntity4>(TEntity entity, TEntity2 entity2, TEntity3 entity3, TEntity4 entity4)
        where TEntity : class
        where TEntity2 : class
        where TEntity3 : class
        where TEntity4 : class
    {
      return ExecuteDbContextAsync(db =>
      {
        db.Set<TEntity>().Add(entity);
        db.Set<TEntity2>().Add(entity2);
        db.Set<TEntity3>().Add(entity3);
        db.Set<TEntity4>().Add(entity4);

        return db.SaveChangesAsync();
      });
    }

    public static Task<T> FindAsync<T>(int id)
        where T : class, IEntity => ExecuteDbContextAsync(db => db.Set<T>().FindAsync(id));

    public static Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
    {
      return ExecuteScopeAsync(serviceprovider =>
        {
          IMediator mediator = serviceprovider.GetService<IMediator>();

          return mediator.Send(request);
        }
      );
    }

    public static Task SendAsync(IRequest request)
    {
      return ExecuteScopeAsync(sp =>
      {
        IMediator mediator = sp.GetService<IMediator>();

        return mediator.Send(request);
      });
    }
  }
}