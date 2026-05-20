using JobTracker.Application.Interfaces;
using MediatR;

namespace JobTracker.Application.Jobs.Commands;

public record DeleteJobCommand(int Id) : IRequest;

public class DeleteJobHandler : IRequestHandler<DeleteJobCommand>
{
    private readonly IJobRepository _repo;
    public DeleteJobHandler(IJobRepository repo) => _repo = repo;

    public async Task Handle(DeleteJobCommand r, CancellationToken ct)
        => await _repo.DeleteAsync(r.Id, ct);
}