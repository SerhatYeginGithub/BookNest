using BookNest.Application.Dtos.Book;
using BookNest.Application.Services;
using MediatR;

namespace BookNest.Application.Features.NoteFeatures.Queries.GetNoteByBookIdQuery;

public sealed class GetNoteByBookIdQueryHandler : IRequestHandler<GetNoteByBookIdQuery, ResultNoteDto>
{
    private readonly INoteService _noteService;

    public GetNoteByBookIdQueryHandler(INoteService noteService)
    {
        _noteService = noteService;
    }

    public async Task<ResultNoteDto> Handle(GetNoteByBookIdQuery request, CancellationToken cancellationToken) =>
        await _noteService.GetByIdAsync(request, cancellationToken);
}
