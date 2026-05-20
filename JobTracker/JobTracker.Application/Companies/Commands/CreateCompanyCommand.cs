using JobTracker.Application.Interfaces;
using JobTracker.Domain.Entities;
using MediatR;

namespace JobTracker.Application.Companies.Commands;

public record CreateCompanyCommand(
    string Name, string Industry, string Website) : IRequest<int>;

public class CreateCompanyHandler
    : IRequestHandler<CreateCompanyCommand, int>
{
    private readonly ICompanyRepository _repo;
    public CreateCompanyHandler(ICompanyRepository repo) => _repo = repo;

    public async Task<int> Handle(
        CreateCompanyCommand r, CancellationToken ct)
    {
        var company = new Company
        {
            Name = r.Name,
            Industry = r.Industry,
            Website = r.Website
        };
        await _repo.AddAsync(company, ct);
        return company.Id;
    }
}