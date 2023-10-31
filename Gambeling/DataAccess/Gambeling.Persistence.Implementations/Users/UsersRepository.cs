using Gambeling.DomainModels.Users;
using Gambeling.Persistence.Implementations.BaseClasses;
using Gambeling.Persistence.Implementations.Context;
using Gambeling.Persistence.Services.Users;
using Microsoft.EntityFrameworkCore;

namespace Gambeling.Persistence.Implementations.Users;

public class UsersRepository : Repository, IUsersRepository
{
    public UsersRepository(IGambelingDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<User?> GetUserByCredintial(string userName, string password)
    {
        return await dbContext.Users
            .FirstOrDefaultAsync(c => c.UserName == userName && c.Password == password);
    }
}
