using BookNest.Application.Dtos;
using MediatR;

namespace BookNest.Application.Features.AuthFeatures.Commands.RegisterCommand;

public sealed record RegisterCommand : IRequest<MessageResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Username { get; set; }
    public string Name { get; set; }
    public string Lastname { get; set; }
}
