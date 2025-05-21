using System.Net;
using AutoMapper;
using Azure.Core;
using BookNest.Application.Dtos.Book;
using BookNest.Application.Features.NoteFeatures.Commands.CreateNoteCommand;
using BookNest.Application.Features.NoteFeatures.Commands.DeleteNoteCommand;
using BookNest.Application.Features.NoteFeatures.Commands.UpdateNoteCommand;
using BookNest.Application.Features.NoteFeatures.Queries.GetNoteByBookIdQuery;
using BookNest.Application.Repositories;
using BookNest.Application.Services;
using BookNest.Application.UnitOfWorks;
using BookNest.Domain.Entities;

namespace BookNest.Persistence.Services;

public sealed class NoteService : INoteService
{
    private readonly INoteRepository _noteRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IBookRepository _bookRepository;
    public NoteService(INoteRepository noteRepository, IUnitOfWork unitOfWork, IMapper mapper, IBookRepository bookRepository)
    {
        _noteRepository = noteRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _bookRepository = bookRepository;
    }

    public async Task CreateAsync(CreateNoteCommand request, CancellationToken cancellationToken)
    {
        await IsBookExistAsync(request.BookId);

        Note note = _mapper.Map<Note>(request);

        await _noteRepository.AddAsync(note);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<ResultNoteDto> GetByIdAsync(GetNoteByBookIdQuery request, CancellationToken cancellationToken = default)
    {
        Note note = await _noteRepository.GetByExpressionAsync(n => n.BookId == request.BookId, cancellationToken);
        if (note == null) 
            throw new Exception("Note not found.");
        return _mapper.Map<ResultNoteDto>(note);
    }

    public async Task HardDeleteAsync(DeleteNoteCommand request, CancellationToken cancellationToken = default)
    {
        await _noteRepository.DeleteByIdAsync(request.Id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task SoftDeleteAsync(DeleteNoteCommand request, CancellationToken cancellationToken = default)
    {
        Note note = await _noteRepository.GetByExpressionAsync(b => b.Id == request.Id);

        if (note is null)
            throw new Exception("Note is not available.");

        note.IsDeleted = true;

        _noteRepository.Update(note);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(UpdateNoteCommand request, CancellationToken cancellationToken = default)
    {
        await IsNoteExistAsync(request.Id);
        await IsBookExistAsync(request.BookId);

        Note note = _mapper.Map<Note>(request);

        _noteRepository.Update(note);
        await _unitOfWork.SaveChangesAsync();
    }

    private async Task IsBookExistAsync(Guid bookId)
    {
        var isBookExist = await _bookRepository.AnyAsync(x => x.Id == bookId);

        if (!isBookExist)
            throw new Exception("Book not found.");
    }

    private async Task IsNoteExistAsync(Guid NoteId)
    {
        var isNoteExist = await _noteRepository.AnyAsync(x => x.Id == NoteId);

        if (!isNoteExist)
            throw new Exception("Note not found.");
    }
}
