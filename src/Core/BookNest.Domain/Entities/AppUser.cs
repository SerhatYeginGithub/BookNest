using System.Security.Principal;
using Microsoft.AspNetCore.Identity;

namespace BookNest.Domain.Entities;

public sealed class AppUser : IdentityUser<Guid>
{
    public string Name { get; set; }
    public string Lastname { get; set; }

    ICollection<Book> Books { get; set; }
}

