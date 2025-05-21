using AutoMapper;
using BookNest.Application.Dtos.Book;
using BookNest.Application.Features.AuthFeatures.Commands.RegisterCommand;
using BookNest.Application.Features.BookFeatures.Commands.CreateBookCommand;
using BookNest.Application.Features.BookFeatures.Commands.UpdateBookCommand;
using BookNest.Application.Features.BookFeatures.Queries.GetAllBooksQuery;
using BookNest.Domain.Entities;

namespace BookNest.Persistence.Mapping;

public sealed class AuthMappingProfile : Profile
{
    public AuthMappingProfile()
    {
        CreateMap<RegisterCommand, AppUser>().ReverseMap();
    }
}
