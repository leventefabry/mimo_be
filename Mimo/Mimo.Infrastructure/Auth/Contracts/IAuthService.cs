using Mimo.Infrastructure.Auth.DTOs;
using Mimo.Infrastructure.Auth.Responses;

namespace Mimo.Infrastructure.Auth.Contracts;

public interface IAuthService
{
    Task<TokenResponseDto?> LoginAsync(UserDto request, CancellationToken token = default);
}