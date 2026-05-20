using JobTracker.Application.Interfaces;
using MediatR;

namespace JobTracker.Application.Applications.Commands;

public record DeleteApplicationCommand(int Id) : IRequest;

public class DeleteApplicationHandler
    : IRequestHandler<DeleteApplicationCommand>
{
    private readonly IApplicationRepository _repo;
    public DeleteApplicationHandler(IApplicationRepository repo)
        => _repo = repo;

    public async Task Handle(
        DeleteApplicationCommand r, CancellationToken ct)
        => await _repo.DeleteAsync(r.Id, ct);
}