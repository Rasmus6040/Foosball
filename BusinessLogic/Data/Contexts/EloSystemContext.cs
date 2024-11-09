using BusinessLogic.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Data.Contexts;

public class EloSystemContext : DbContext
{
    public DbSet<MatchEntity> Matches { get; set; }
    public DbSet<PlayerEntity> Players { get; set; }
    public DbSet<PlayerMatchEntity> PlayerMatches { get; set; }
    
    public EloSystemContext(DbContextOptions<EloSystemContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}