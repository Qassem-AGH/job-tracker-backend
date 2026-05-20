using Microsoft.EntityFrameworkCore;
using JobTracker.Domain.Entities;

namespace JobTracker.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Company> Companies => Set<Company>();
    public DbSet<Job> Jobs => Set<Job>();
    public DbSet<JobTracker.Domain.Entities.Application> Applications
        => Set<JobTracker.Domain.Entities.Application>();
}