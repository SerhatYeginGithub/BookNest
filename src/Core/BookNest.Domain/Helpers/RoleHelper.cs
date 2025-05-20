using BookNest.Domain.Enums;

namespace BookNest.Domain.Helpers;

public static class RoleHelper
{
    public static string GetRoleString(Role role)
    {
        return role switch
        {
            Role.Admin => "admin",
            Role.User => "user",
            _ => throw new ArgumentOutOfRangeException(nameof(role), role, null)
        };
    }
}
