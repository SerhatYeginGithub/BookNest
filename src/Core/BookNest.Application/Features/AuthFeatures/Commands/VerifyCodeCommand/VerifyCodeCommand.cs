using BookNest.Domain.Dtos;
using MediatR;

namespace BookNest.Application.Features.AuthFeatures.Commands.VerifyCodeCommand;

public sealed record VerifyCodeCommand(string Email, string Code) : IRequest<MessageResponse>;
