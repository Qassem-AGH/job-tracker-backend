using JobTracker.Application.Interfaces;
using JobTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using AppEntity = JobTracker.Domain.Entities.Application;

namespace JobTracker.Infrastructure.Repositories;

public class ApplicationRepository : IApplicationRepository
{
    private readonly AppDbContext _ctx;
    public ApplicationRepository(AppDbContext ctx) => _ctx = ctx;

    public Task<List<AppEntity>> GetAllAsync(CancellationToken ct)
        => _ctx.Applications.Include(a => a.Job).ToListAsync(ct);

    public async Task<AppEntity?> GetByIdAsync(int id, CancellationToken ct)
        => await _ctx.Applications.Include(a => a.Job)
               .FirstOrDefaultAsync(a => a.Id == id, ct);

    public async Task AddAsync(AppEntity a, CancellationToken ct)
    {
        var job = await _ctx.Jobs.FindAsync(new object[] { a.JobId }, ct);
        if (job is not null)
        {
            a.Job = job;
            _ctx.Applications.Add(a);
            await _ctx.SaveChangesAsync(ct);
        }
    }

    public async Task UpdateAsync(AppEntity a, CancellationToken ct)
    {
        _ctx.Applications.Update(a);
        await _ctx.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(int id, CancellationToken ct)
    {
        var a = await _ctx.Applications
            .FindAsync(new object[] { id }, ct);
        if (a is not null)
        {
            _ctx.Applications.Remove(a);
            await _ctx.SaveChangesAsync(ct);
        }
    }
}