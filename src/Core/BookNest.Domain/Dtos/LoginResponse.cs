namespace BookNest.Domain.Dtos;

public sealed record LoginResponse(
 string Token,
 string RefreshToken,
 DateTime? RefreshTokenExpires,
 Guid AppUserId);
