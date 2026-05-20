using JobTracker.Application.Interfaces;
using MediatR;

namespace JobTracker.Application.Companies.Commands;

public record DeleteCompanyCommand(int Id) : IRequest;

public class DeleteCompanyHandler : IRequestHandler<DeleteCompanyCommand>
{
    private readonly ICompanyRepository _repo;
    public DeleteCompanyHandler(ICompanyRepository repo) => _repo = repo;

    public async Task Handle(DeleteCompanyCommand r, CancellationToken ct)
        => await _repo.DeleteAsync(r.Id, ct);
}