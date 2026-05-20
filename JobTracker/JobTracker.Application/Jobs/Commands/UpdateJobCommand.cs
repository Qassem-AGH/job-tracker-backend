using JobTracker.Application.Interfaces;
using MediatR;

namespace JobTracker.Application.Jobs.Commands;

public record UpdateJobCommand(
    int Id, string Title, string Description, int CompanyId) : IRequest;

public class UpdateJobHandler : IRequestHandler<UpdateJobCommand>
{
    private readonly IJobRepository _repo;
    public UpdateJobHandler(IJobRepository repo) => _repo = repo;

    public async Task Handle(UpdateJobCommand r, CancellationToken ct)
    {
        var job = await _repo.GetByIdAsync(r.Id, ct);
        if (job is null) return;
        job.Title = r.Title;
        job.Description = r.Description;
        job.CompanyId = r.CompanyId;
        await _repo.UpdateAsync(job, ct);
    }
}