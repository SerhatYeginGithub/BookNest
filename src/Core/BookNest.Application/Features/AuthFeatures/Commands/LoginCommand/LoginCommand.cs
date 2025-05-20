using BookNest.Application.Dtos;
using MediatR;

namespace BookNest.Application.Features.AuthFeatures.Commands.LoginCommand;

public sealed record LoginCommand(
 string UserNameOrEmail,
 string Password) : IRequest<LoginResponse>;