﻿using Microsoft.AspNetCore.Identity;

namespace BookNest.Domain.Entities;

public sealed class AppRole : IdentityRole<Guid>
{
    public AppRole()
    {
        Id = Guid.NewGuid();
    }
}
