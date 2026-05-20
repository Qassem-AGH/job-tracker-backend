using JobTracker.Application.Interfaces;
using JobTracker.Domain.Entities;
using JobTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace JobTracker.Infrastructure.Repositories;

public class CompanyRepository : ICompanyRepository
{
    private readonly AppDbContext _ctx;
    public CompanyRepository(AppDbContext ctx) => _ctx = ctx;

    public Task<List<Company>> GetAllAsync(CancellationToken ct)
        => _ctx.Companies.ToListAsync(ct);

    public async Task<Company?> GetByIdAsync(int id, CancellationToken ct)
        => await _ctx.Companies.FindAsync(new object[] { id }, ct);

    public async Task AddAsync(Company c, CancellationToken ct)
    {
        _ctx.Companies.Add(c);
        await _ctx.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(Company c, CancellationToken ct)
    {
        _ctx.Companies.Update(c);
        await _ctx.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(int id, CancellationToken ct)
    {
        var c = await _ctx.Companies.FindAsync(new object[] { id }, ct);
        if (c is not null)
        {
            _ctx.Companies.Remove(c);
            await _ctx.SaveChangesAsync(ct);
        }
    }
}