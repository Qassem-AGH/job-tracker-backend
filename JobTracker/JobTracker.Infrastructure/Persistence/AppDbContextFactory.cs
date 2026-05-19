using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace JobTracker.Infrastructure.Persistence;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var opts = new DbContextOptionsBuilder<AppDbContext>();

        opts.UseSqlServer(
            "Server=(localdb)\\mssqllocaldb;Database=JobTrackerDb;Trusted_Connection=True;TrustServerCertificate=True;");

        return new AppDbContext(opts.Options);
    }
}