using AutoMapper;
using BookNest.Application.Dtos.Book;
using BookNest.Application.Features.BookFeatures.Commands.CreateBookCommand;
using BookNest.Application.Features.BookFeatures.Commands.UpdateBookCommand;
using BookNest.Application.Features.BookFeatures.Queries.GetAllBooksQuery;
using BookNest.Domain.Entities;

namespace BookNest.Persistence.Mapping;

public sealed class BookMappingProfile : Profile
{
    public BookMappingProfile()
    {
        CreateMap<CreateBookCommand, Book>().ReverseMap();
        CreateMap<GetAllBooksResponse, Book>().ReverseMap();
        CreateMap<BookDetailDto, Book>().ReverseMap();
        CreateMap<UpdateBookCommand, Book>()
         .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false))
         .ReverseMap();
    }
}
