using JobTracker.Domain.Entities;

namespace JobTracker.Application.Interfaces;

public interface IJobRepository
{
    Task<List<Job>> GetAllAsync(CancellationToken ct);
    Task<Job?> GetByIdAsync(int id, CancellationToken ct);
    Task AddAsync(Job job, CancellationToken ct);
    Task UpdateAsync(Job job, CancellationToken ct);
    Task DeleteAsync(int id, CancellationToken ct);
}