using AutoMapper;
using BookNest.Application.Dtos.Book;
using BookNest.Application.Features.BookFeatures.Commands.UpdateBookCommand;
using BookNest.Application.Features.NoteFeatures.Commands.CreateNoteCommand;
using BookNest.Application.Features.NoteFeatures.Commands.UpdateNoteCommand;
using BookNest.Domain.Entities;

namespace BookNest.Persistence.Mapping;

public sealed class NoteMappingProfile : Profile
{
    public NoteMappingProfile()
    {
        CreateMap<CreateNoteCommand, Note>();
        CreateMap<Note, ResultNoteDto>();
        CreateMap<UpdateNoteCommand, Note>()
        .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false))
        .ReverseMap();
    }
}
