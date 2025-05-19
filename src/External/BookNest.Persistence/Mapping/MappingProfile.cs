using AutoMapper;
using BookNest.Application.Features.AuthFeatures.Commands.RegisterCommand;
using BookNest.Application.Features.BookFeatures.Commands.CreateBookCommand;
using BookNest.Application.Features.BookFeatures.Commands.UpdateBookCommand;
using BookNest.Application.Features.BookFeatures.Queries.GetAllBooksQuery;
using BookNest.Domain.Dtos.Book;
using BookNest.Domain.Entities;

namespace BookNest.Persistence.Mapping;

public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterCommand, AppUser>().ReverseMap();
        CreateMap<CreateBookCommand, Book>().ReverseMap();
        CreateMap<GetAllBooksResponse, Book>().ReverseMap();
        CreateMap<BookDetailDto, Book>().ReverseMap();
        CreateMap<UpdateBookCommand, Book>()
         .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false))
         .ReverseMap();
    }
}
