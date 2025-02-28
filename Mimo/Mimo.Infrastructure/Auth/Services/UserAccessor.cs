using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Mimo.Application.Contracts;

namespace Mimo.Infrastructure.Auth.Services;

public class UserAccessor(IHttpContextAccessor httpContextAccessor) : IUserAccessor
{
    public string? GetUsername() => httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Name);

    public Guid? GetUserId()
    {
        var nameIdentifier = httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (Guid.TryParse(nameIdentifier, out var id))
        {
            return id;
        }
        
        return null;
    }
}