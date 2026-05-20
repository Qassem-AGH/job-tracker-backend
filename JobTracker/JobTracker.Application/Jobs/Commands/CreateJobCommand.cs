using JobTracker.Application.Interfaces;
using JobTracker.Domain.Entities;
using MediatR;

namespace JobTracker.Application.Jobs.Commands;

public record CreateJobCommand(
    string Title, string Description, int CompanyId) : IRequest<int>;

public class CreateJobHandler : IRequestHandler<CreateJobCommand, int>
{
    private readonly IJobRepository _repo;
    public CreateJobHandler(IJobRepository repo) => _repo = repo;

    public async Task<int> Handle(CreateJobCommand r, CancellationToken ct)
    {
        var job = new Job
        {
            Title = r.Title,
            Description = r.Description,
            CompanyId = r.CompanyId
        };
        await _repo.AddAsync(job, ct);
        return job.Id;
    }
}