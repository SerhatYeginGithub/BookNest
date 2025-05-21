using BookNest.Application.Dtos.Book;
using MediatR;

namespace BookNest.Application.Features.NoteFeatures.Queries.GetNoteByBookIdQuery;

public sealed record GetNoteByBookIdQuery(Guid BookId) : IRequest<ResultNoteDto>;
