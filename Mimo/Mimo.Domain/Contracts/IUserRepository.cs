using Mimo.Domain.DTOs;
using Mimo.Domain.Entities;

namespace Mimo.Domain.Contracts;

public interface IUserRepository
{
    Task<User?> GetUserByUsernameAsync(string username, bool trackChanges, CancellationToken token = default);

    Task<UserProgressAndAchievementsQueryDto?> GetUserProgressAndAchievementsAsync(Guid id, CancellationToken token = default);
}