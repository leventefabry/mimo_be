using Mimo.Application.Contracts.Responses;
using Mimo.Application.DTOs;

namespace Mimo.Application.Contracts;

public interface IAuthService
{
    Task<TokenResponseDto?> LoginAsync(UserDto request, CancellationToken token = default);
}