using JobTracker.Application.Applications.DTOs;
using JobTracker.Application.Interfaces;
using MediatR;

namespace JobTracker.Application.Applications.Queries;

public record GetAllApplicationsQuery() : IRequest<List<ApplicationDto>>;

public class GetAllApplicationsHandler
    : IRequestHandler<GetAllApplicationsQuery, List<ApplicationDto>>
{
    private readonly IApplicationRepository _repo;
    public GetAllApplicationsHandler(IApplicationRepository repo)
        => _repo = repo;

    public async Task<List<ApplicationDto>> Handle(
        GetAllApplicationsQuery r, CancellationToken ct)
    {
        var list = await _repo.GetAllAsync(ct);
        return list.Select(a => new ApplicationDto
        {
            Id = a.Id,
            JobId = a.JobId,
            JobTitle = a.Job?.Title ?? "",
            Status = a.Status,
            AppliedDate = a.AppliedDate,
            Notes = a.Notes
        }).ToList();
    }
}