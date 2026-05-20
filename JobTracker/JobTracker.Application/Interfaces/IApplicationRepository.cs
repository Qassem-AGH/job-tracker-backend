using Microsoft.Extensions.DependencyInjection;

namespace JobTracker.Application.Interfaces;

public interface IApplicationRepository
{
    Task<List<JobTracker.Domain.Entities.Application>> GetAllAsync(CancellationToken ct);
    Task<JobTracker.Domain.Entities.Application?> GetByIdAsync(int id, CancellationToken ct);
    Task AddAsync(JobTracker.Domain.Entities.Application application, CancellationToken ct);
    Task UpdateAsync(JobTracker.Domain.Entities.Application application, CancellationToken ct);
    Task DeleteAsync(int id, CancellationToken ct);
}