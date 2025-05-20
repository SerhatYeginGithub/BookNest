using BookNest.Application.Dtos;
using BookNest.Domain.Entities;

namespace BookNest.Application.Abstractions;

public interface IJwtProvider
{
    Task<LoginResponse> CreateTokenAsync(AppUser user);
}