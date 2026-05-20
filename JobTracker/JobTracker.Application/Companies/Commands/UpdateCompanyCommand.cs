using JobTracker.Application.Interfaces;
using MediatR;

namespace JobTracker.Application.Companies.Commands;

public record UpdateCompanyCommand(
    int Id, string Name, string Industry, string Website) : IRequest;

public class UpdateCompanyHandler : IRequestHandler<UpdateCompanyCommand>
{
    private readonly ICompanyRepository _repo;
    public UpdateCompanyHandler(ICompanyRepository repo) => _repo = repo;

    public async Task Handle(UpdateCompanyCommand r, CancellationToken ct)
    {
        var company = await _repo.GetByIdAsync(r.Id, ct);
        if (company is null) return;
        company.Name = r.Name;
        company.Industry = r.Industry;
        company.Website = r.Website;
        await _repo.UpdateAsync(company, ct);
    }
}