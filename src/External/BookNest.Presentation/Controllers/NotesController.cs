using BookNest.Application.Features.NoteFeatures.Commands.CreateNoteCommand;
using BookNest.Application.Features.NoteFeatures.Commands.DeleteNoteCommand;
using BookNest.Application.Features.NoteFeatures.Commands.UpdateNoteCommand;
using BookNest.Application.Features.NoteFeatures.Queries.GetNoteByBookIdQuery;
using BookNest.Infrastructure.Authorization;
using BookNest.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookNest.Presentation.Controllers;

[RoleFilter("User")]
public sealed class NotesController : ApiController
{
    public NotesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[Action]")]
    public async Task<IActionResult> CreateNote(CreateNoteCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);

        return Ok(response);
    }

    [HttpPut("[Action]")]
    public async Task<IActionResult> UpdateNote(UpdateNoteCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request,cancellationToken);

        return Ok(response);
    }

    [HttpGet("[Action]")]
    public async Task<IActionResult> GetNote(Guid bookId, CancellationToken cancellationToken)
    {
        var request = new GetNoteByBookIdQuery(bookId);
        var response = await _mediator.Send(request, cancellationToken);

        return Ok(response);
    }

    [HttpDelete("[Action]")]
    public async Task<IActionResult> DeleteNote(DeleteNoteCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
