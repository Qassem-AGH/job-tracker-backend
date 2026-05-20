using JobTracker.Application.Applications.Commands;
using JobTracker.Application.Applications.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApplicationsController : ControllerBase
{
    private readonly IMediator _mediator;
    public ApplicationsController(IMediator mediator)
        => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = await _mediator
                .Send(new GetAllApplicationsQuery());
            return Ok(result);
        }
        catch (Exception ex) { return StatusCode(500, ex.Message); }
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateApplicationCommand cmd)
    {
        var id = await _mediator.Send(cmd);
        return CreatedAtAction(nameof(GetAll), new { id }, null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id, [FromBody] UpdateApplicationCommand cmd)
    {
        if (id != cmd.Id) return BadRequest();
        await _mediator.Send(cmd);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteApplicationCommand(id));
        return NoContent();
    }
}