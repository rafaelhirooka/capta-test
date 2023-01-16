using Capta.Models;
using Microsoft.EntityFrameworkCore;

namespace Capta.Data
{
  public class CaptaContext : DbContext
  {
    public CaptaContext(DbContextOptions<CaptaContext> options) : base(options) { }

    public DbSet<Client> Clients { get; set; }
    public DbSet<ClientSituation> ClientSituations { get; set; }
    public DbSet<ClientType> ClientTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Client>()
        .HasIndex(u => u.Document)
        .IsUnique();

      modelBuilder.Entity<ClientSituation>().HasData(
        new ClientSituation
        {
          Id = 1,
          Name = "Active",
        },
        new ClientSituation
        {
          Id = 2,
          Name = "Inactive",
        }
      );

      modelBuilder.Entity<ClientType>().HasData(
        new ClientType
        {
          Id = 1,
          Name = "Person",
        },
        new ClientType
        {
          Id = 2,
          Name = "Company",
        }
      );
    }
  }
}
