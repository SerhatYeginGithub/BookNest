﻿using BookNest.Infrastructure.Authentication;
using Microsoft.Extensions.Options;

namespace MindMateJourney.WebApi.OptionsSetup;


public sealed class JwtOptionsSetup : IConfigureOptions<JwtOptions>
{
    private readonly IConfiguration _configuration;

    public JwtOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(JwtOptions options)
    {
        _configuration.GetSection("Jwt").Bind(options);
    }
}
