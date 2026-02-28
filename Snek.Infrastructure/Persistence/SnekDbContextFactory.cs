using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Snek.Infrastructure.Persistence;

public sealed class SnekDbContextFactory : IDesignTimeDbContextFactory<SnekDbContext>
{
    public SnekDbContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<SnekDbContext>()
            .UseSqlite("Data Source=snek-design.db")
            .Options;
        return new SnekDbContext(options);
    }
}
