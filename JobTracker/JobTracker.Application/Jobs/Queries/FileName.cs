using JobTracker.Application.Interfaces;
using JobTracker.Application.Jobs.DTOs;
using MediatR;

namespace JobTracker.Application.Jobs.Queries;

public record GetAllJobsQuery() : IRequest<List<JobDto>>;

public class GetAllJobsHandler
    : IRequestHandler<GetAllJobsQuery, List<JobDto>>
{
    private readonly IJobRepository _repo;
    public GetAllJobsHandler(IJobRepository repo) => _repo = repo;

    public async Task<List<JobDto>> Handle(
        GetAllJobsQuery r, CancellationToken ct)
    {
        var list = await _repo.GetAllAsync(ct);
        return list.Select(j => new JobDto
        {
            Id = j.Id,
            Title = j.Title,
            Description = j.Description,
            CompanyId = j.CompanyId,
            CompanyName = j.Company?.Name ?? ""
        }).ToList();
    }
}