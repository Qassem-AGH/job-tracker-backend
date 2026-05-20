using JobTracker.Application.Companies.DTOs;
using JobTracker.Application.Interfaces;
using MediatR;

namespace JobTracker.Application.Companies.Queries;

public record GetAllCompaniesQuery() : IRequest<List<CompanyDto>>;

public class GetAllCompaniesHandler
    : IRequestHandler<GetAllCompaniesQuery, List<CompanyDto>>
{
    private readonly ICompanyRepository _repo;
    public GetAllCompaniesHandler(ICompanyRepository repo) => _repo = repo;

    public async Task<List<CompanyDto>> Handle(
        GetAllCompaniesQuery r, CancellationToken ct)
    {
        var list = await _repo.GetAllAsync(ct);
        return list.Select(c => new CompanyDto
        {
            Id = c.Id,
            Name = c.Name,
            Industry = c.Industry,
            Website = c.Website
        }).ToList();
    }
}