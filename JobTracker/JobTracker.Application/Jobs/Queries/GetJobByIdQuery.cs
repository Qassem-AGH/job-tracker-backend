using JobTracker.Application.Interfaces;
using JobTracker.Application.Jobs.DTOs;
using MediatR;

namespace JobTracker.Application.Jobs.Queries;

public record GetJobByIdQuery(int Id) : IRequest<JobDto?>;

public class GetJobByIdHandler : IRequestHandler<GetJobByIdQuery, JobDto?>
{
    private readonly IJobRepository _repo;
    public GetJobByIdHandler(IJobRepository repo) => _repo = repo;

    public async Task<JobDto?> Handle(
        GetJobByIdQuery r, CancellationToken ct)
    {
        var j = await _repo.GetByIdAsync(r.Id, ct);
        if (j is null) return null;
        return new JobDto
        {
            Id = j.Id,
            Title = j.Title,
            Description = j.Description,
            CompanyId = j.CompanyId,
            CompanyName = j.Company?.Name ?? ""
        };
    }
}