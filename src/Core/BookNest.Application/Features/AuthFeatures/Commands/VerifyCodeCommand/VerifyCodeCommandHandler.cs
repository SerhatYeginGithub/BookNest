﻿using BookNest.Application.Dtos;
using BookNest.Application.Services;
using MediatR;


namespace BookNest.Application.Features.AuthFeatures.Commands.VerifyCodeCommand;

public sealed class VerifyCodeCommandHandler : IRequestHandler<VerifyCodeCommand, MessageResponse>
{
    private readonly IAuthService _authService;

    public VerifyCodeCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<MessageResponse> Handle(VerifyCodeCommand request, CancellationToken cancellationToken)
    {
        await _authService.VerifyCodeAsync(request, cancellationToken);
        return new("User registered successfully.");
    }
}
