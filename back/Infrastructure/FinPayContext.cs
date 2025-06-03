using Domain.Entities;
using Infrastructure.ModelBuilders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class FinPayContext : DbContext
{
    public FinPayContext(DbContextOptions<FinPayContext> options) : base(options)
    {
        var pendingMigrations = Database.GetPendingMigrations();
        if (pendingMigrations.Any())
            Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Configure();

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<User> Users { get; set; }
}
