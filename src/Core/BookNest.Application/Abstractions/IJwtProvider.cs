using BookNest.Application.Dtos;
using BookNest.Domain.Entities;
using BookNest.Domain.Enums;

namespace BookNest.Application.Abstractions;

public interface IJwtProvider
{
    Task<LoginResponse> CreateTokenAsync(AppUser user, string role);
}