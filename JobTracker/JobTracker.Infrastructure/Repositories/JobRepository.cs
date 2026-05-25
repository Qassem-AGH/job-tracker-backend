using JobTracker.Application.Interfaces;
using JobTracker.Domain.Entities;
using JobTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace JobTracker.Infrastructure.Repositories;

public class JobRepository : IJobRepository
{
    private readonly AppDbContext _ctx;
    public JobRepository(AppDbContext ctx) => _ctx = ctx;

    public Task<List<Job>> GetAllAsync(CancellationToken ct)
        => _ctx.Jobs.Include(j => j.Company).ToListAsync(ct);

    public async Task<Job?> GetByIdAsync(int id, CancellationToken ct)
        => await _ctx.Jobs.Include(j => j.Company)
               .FirstOrDefaultAsync(j => j.Id == id, ct);

    public async Task AddAsync(Job j, CancellationToken ct)
    {
        var company = await _ctx.Companies.FindAsync(new object[] { j.CompanyId }, ct);
        if (company is not null)
        {
            j.Company = company;
            _ctx.Jobs.Add(j);
            await _ctx.SaveChangesAsync(ct);
        }
    }

    public async Task UpdateAsync(Job j, CancellationToken ct)
    {
        _ctx.Jobs.Update(j);
        await _ctx.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(int id, CancellationToken ct)
    {
        var j = await _ctx.Jobs.FindAsync(new object[] { id }, ct);
        if (j is not null)
        {
            _ctx.Jobs.Remove(j);
            await _ctx.SaveChangesAsync(ct);
        }
    }
}