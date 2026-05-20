using JobTracker.Application.Interfaces;
using JobTracker.Infrastructure.Persistence;
using JobTracker.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobTracker.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddDbContext<AppDbContext>(opts =>
            opts.UseSqlServer(
                config.GetConnectionString("DefaultConnection")));

        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<IJobRepository, JobRepository>();
        services.AddScoped<IApplicationRepository, ApplicationRepository>();

        return services;
    }
}