using JobTracker.Application.Companies.DTOs;
using JobTracker.Application.Interfaces;
using MediatR;

namespace JobTracker.Application.Companies.Queries;

public record GetCompanyByIdQuery(int Id) : IRequest<CompanyDto?>;

public class GetCompanyByIdHandler
    : IRequestHandler<GetCompanyByIdQuery, CompanyDto?>
{
    private readonly ICompanyRepository _repo;
    public GetCompanyByIdHandler(ICompanyRepository repo) => _repo = repo;

    public async Task<CompanyDto?> Handle(
        GetCompanyByIdQuery r, CancellationToken ct)
    {
        var c = await _repo.GetByIdAsync(r.Id, ct);
        if (c is null) return null;
        return new CompanyDto
        {
            Id = c.Id,
            Name = c.Name,
            Industry = c.Industry,
            Website = c.Website
        };
    }
}