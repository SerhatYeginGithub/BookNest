using System.Globalization;

namespace BookNest.Application.Features.AuthFeatures.Commands.LoginCommand;

public sealed record RegisterCommand 
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Username { get; set; }
    public string Name { get; set; }
    public string Lastname { get; set; }
}
