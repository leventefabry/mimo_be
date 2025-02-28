using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Mimo.Application.Contracts;
using Mimo.Application.Contracts.Responses;
using Mimo.Application.DTOs;
using Mimo.Domain.Contracts;
using Mimo.Domain.Entities;

namespace Mimo.Infrastructure.Auth.Services;

public class AuthService(IUserRepository userRepository, IConfiguration configuration) : IAuthService
{
    public async Task<TokenResponseDto?> LoginAsync(UserDto request, CancellationToken token = default)
    {
        var user = await userRepository.GetUserByUsernameAsync(request.Username, false, token);
        if (user is null)
        {
            return null;
        }

        if (!user.PasswordHash.Equals(request.Password))
        {
            return null;
        }

        return CreateTokenResponse(user);
    }

    private TokenResponseDto CreateTokenResponse(User? user)
    {
        return new TokenResponseDto
        {
            AccessToken = CreateToken(user)
        };
    }

    private string CreateToken(User? user)
    {
        if (user is null)
        {
            return string.Empty;
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.Username),
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(configuration.GetValue<string>("AppSettings:Token")!));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        var tokenDescriptor = new JwtSecurityToken(
            issuer: configuration.GetValue<string>("AppSettings:Issuer"),
            audience: configuration.GetValue<string>("AppSettings:Audience"),
            claims: claims,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }
}