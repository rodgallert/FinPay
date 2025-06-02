using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class FinPayContext : DbContext
{
    public FinPayContext(DbContextOptions<FinPayContext> options) : base(options)
    {
        Database.EnsureCreated();
        
        var pendingMigrations = Database.GetPendingMigrations();
        if (pendingMigrations.Any())
            Database.Migrate();
    }
}
