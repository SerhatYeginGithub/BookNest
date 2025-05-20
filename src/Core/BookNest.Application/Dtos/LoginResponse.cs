namespace BookNest.Application.Dtos;

public sealed record LoginResponse(
 string Token,
 string RefreshToken,
 DateTime? RefreshTokenExpires,
 Guid AppUserId);
