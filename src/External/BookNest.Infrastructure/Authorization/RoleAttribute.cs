using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using System;
using BookNest.Domain.Constants;

namespace BookNest.Infrastructure.Authorization;

public sealed class RoleAttribute : Attribute, IAuthorizationFilter
{
    private readonly string _role;

    public RoleAttribute(string role)
    {
        _role = role;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var userRoleClaim = context.HttpContext.User.FindFirst("UserRole");

        if (userRoleClaim is null)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        if (userRoleClaim.Value.ToLowerInvariant() == Role.Admin.ToLowerInvariant())
        {
            return;
        }

        if (userRoleClaim.Value.ToLowerInvariant() != _role.ToLowerInvariant())
        {
            context.Result = new UnauthorizedResult();
        }

    }
}