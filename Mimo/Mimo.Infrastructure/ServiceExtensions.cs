﻿using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Mimo.Application.Contracts;
using Mimo.Infrastructure.Auth.Services;

namespace Mimo.Infrastructure;

public static class ServiceExtensions
{
    public static void AddAuthServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["AppSettings:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = configuration["AppSettings:Audience"],
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["AppSettings:Token"]!)),
                    ValidateIssuerSigningKey = true
                };
            });

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserAccessor, UserAccessor>();
        services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }
}