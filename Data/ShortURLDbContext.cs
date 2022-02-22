using AwesomeUrl.Models;
using Microsoft.EntityFrameworkCore;

namespace AwesomeUrl.Data
{
  public class ShortURLDbContext : DbContext
  {
    public ShortURLDbContext(DbContextOptions<ShortURLDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // Ensure that PostgreSQL will create uuid automatically.
      modelBuilder.HasPostgresExtension("uuid-ossp");
      modelBuilder
          .Entity<ShortURL>()
          .Property(e => e.Id)
          .HasDefaultValueSql("uuid_generate_v4()");

      modelBuilder
        .Entity<ShortURL>()
        .Property(e => e.CreatedAt)
        .HasDefaultValueSql("now()");
    }
    public DbSet<ShortURL> ShortURLs => Set<ShortURL>();
  }
}

