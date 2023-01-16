using Capta.Models;
using Microsoft.EntityFrameworkCore;

namespace Capta.Data
{
  public class CaptaContext : DbContext
  {
    public CaptaContext(DbContextOptions<CaptaContext> options): base(options) { }

    public DbSet<Client> Clients { get; set; }
    public DbSet<ClientSituation> ClientSituations { get; set; }
    public DbSet<ClientType> ClientTypes { get; set; }
  }
}
