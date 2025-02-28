using Mimo.Infrastructure.Auth.DTOs;
using Mimo.Infrastructure.Auth.Responses;

namespace Mimo.Application.Contracts;

public interface IAuthService
{
    Task<TokenResponseDto?> LoginAsync(UserDto request, CancellationToken token = default);
}