using BookNest.Application.Dtos.Book;
using BookNest.Application.Features.NoteFeatures.Commands.CreateNoteCommand;
using BookNest.Application.Features.NoteFeatures.Commands.DeleteNoteCommand;
using BookNest.Application.Features.NoteFeatures.Commands.UpdateNoteCommand;
using BookNest.Application.Features.NoteFeatures.Queries.GetNoteByBookIdQuery;

namespace BookNest.Application.Services;

public interface INoteService
{
    Task CreateAsync(CreateNoteCommand request, CancellationToken cancellationToken = default);
    Task UpdateAsync(UpdateNoteCommand request, CancellationToken cancellationToken = default);
    Task<ResultNoteDto>GetByIdAsync(GetNoteByBookIdQuery request, CancellationToken cancellationToken = default);
    Task HardDeleteAsync(DeleteNoteCommand request, CancellationToken cancellationToken = default);
    Task SoftDeleteAsync(DeleteNoteCommand request, CancellationToken cancellationToken = default);
}
