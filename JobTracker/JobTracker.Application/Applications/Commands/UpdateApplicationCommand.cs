using JobTracker.Application.Interfaces;
using MediatR;

namespace JobTracker.Application.Applications.Commands;

public record UpdateApplicationCommand(
    int Id, string Status, string Notes) : IRequest;

public class UpdateApplicationHandler
    : IRequestHandler<UpdateApplicationCommand>
{
    private readonly IApplicationRepository _repo;
    public UpdateApplicationHandler(IApplicationRepository repo)
        => _repo = repo;

    public async Task Handle(
        UpdateApplicationCommand r, CancellationToken ct)
    {
        var app = await _repo.GetByIdAsync(r.Id, ct);
        if (app is null) return;
        app.Status = r.Status;
        app.Notes = r.Notes;
        await _repo.UpdateAsync(app, ct);
    }
}