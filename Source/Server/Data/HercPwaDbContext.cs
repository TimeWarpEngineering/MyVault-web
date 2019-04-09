namespace Herc.Pwa.Server.Data
{
  using System.Data;
  using System.Threading.Tasks;
  using Herc.Pwa.Server.Entities;
  using Microsoft.EntityFrameworkCore;
  using Microsoft.EntityFrameworkCore.Storage;

  public class HercPwaDbContext : DbContext
  {
    private IDbContextTransaction DbContextTransaction { get; set; }

    public HercPwaDbContext(DbContextOptions<HercPwaDbContext> options) : base(options) { }

    public DbSet<Application> Application { get; set; }
    public DbSet<AssetDefinition> AssetDefinitions { get; set; }
    public DbSet<MetricDefinition> MetricDefinitions { get; set; }

    public async Task BeginTransactionAsync()
    {
      if (DbContextTransaction != null)
      {
        return;
      }

      DbContextTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted).ConfigureAwait(false);
    }

    public async Task CommitTransactionAsync()
    {
      try
      {
        await SaveChangesAsync().ConfigureAwait(false);

        DbContextTransaction?.Commit();
      }
      catch
      {
        RollbackTransaction();
        throw;
      }
      finally
      {
        if (DbContextTransaction != null)
        {
          DbContextTransaction.Dispose();
          DbContextTransaction = null;
        }
      }
    }

    public void RollbackTransaction()
    {
      try
      {
        DbContextTransaction?.Rollback();
      }
      finally
      {
        if (DbContextTransaction != null)
        {
          DbContextTransaction.Dispose();
          DbContextTransaction = null;
        }
      }
    }
  }
}
