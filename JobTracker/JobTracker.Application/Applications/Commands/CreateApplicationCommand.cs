using JobTracker.Application.Interfaces;
using MediatR;

namespace JobTracker.Application.Applications.Commands;

public record CreateApplicationCommand(
    int JobId, string Status, string Notes) : IRequest<int>;

public class CreateApplicationHandler
    : IRequestHandler<CreateApplicationCommand, int>
{
    private readonly IApplicationRepository _repo;
    public CreateApplicationHandler(IApplicationRepository repo)
        => _repo = repo;

    public async Task<int> Handle(
        CreateApplicationCommand r, CancellationToken ct)
    {
        var app = new Domain.Entities.Application
        {
            JobId = r.JobId,
            Status = r.Status,
            Notes = r.Notes
        };
        await _repo.AddAsync(app, ct);
        return app.Id;
    }
}