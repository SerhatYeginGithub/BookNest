using System.Security.Principal;
using Microsoft.AspNetCore.Identity;

namespace BookNest.Domain.Entities;

public sealed class AppUser : IdentityUser<Guid>
{
    public AppUser()
    {
        Id = Guid.NewGuid();
    }
    public string Name { get; set; }
    public string Lastname { get; set; }

    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpires { get; set; }
    ICollection<Book> Books { get; set; }
}

