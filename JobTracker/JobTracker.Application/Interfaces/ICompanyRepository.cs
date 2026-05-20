using JobTracker.Domain.Entities;

namespace JobTracker.Application.Interfaces;

public interface ICompanyRepository
{
    Task<List<Company>> GetAllAsync(CancellationToken ct);
    Task<Company?> GetByIdAsync(int id, CancellationToken ct);
    Task AddAsync(Company company, CancellationToken ct);
    Task UpdateAsync(Company company, CancellationToken ct);
    Task DeleteAsync(int id, CancellationToken ct);
}