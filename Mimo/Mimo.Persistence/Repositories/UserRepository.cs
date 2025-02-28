using Microsoft.EntityFrameworkCore;
using Mimo.Domain.Contracts;
using Mimo.Domain.Entities;
using Mimo.Persistence.Data;

namespace Mimo.Persistence.Repositories;

public class UserRepository(MimoDbContext context) : RepositoryBase<User>(context), IUserRepository
{
    public async Task<User?> GetUserByUsernameAsync(string username, bool trackChanges,
        CancellationToken token = default) =>
        await FindByCondition(c => c.Username.Equals(username), trackChanges)
            .SingleOrDefaultAsync(token);
}