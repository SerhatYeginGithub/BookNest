using BookNest.Application.Dtos;
using MediatR;

namespace BookNest.Application.Features.AuthFeatures.Commands.CreateTokenByRefreshTokenCommand;

public sealed record CreateTokenByRefreshTokenCommand(Guid UserId, string RefreshToken) : IRequest<LoginResponse>;
