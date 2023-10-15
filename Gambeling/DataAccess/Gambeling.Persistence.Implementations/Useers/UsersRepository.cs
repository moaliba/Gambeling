using Gambeling.DomainModels.Users;
using Gambeling.Persistence.Implementations.BaseClasses;
using Gambeling.Persistence.Implementations.Context;
using Gambeling.Persistence.Services.Users;
using Microsoft.EntityFrameworkCore;

namespace Gambeling.Persistence.Implementations.Useers;

public class UsersRepository : Repository, IUsersRepository
{
    public UsersRepository(IGambelingDbContext DBContex) : base(DBContex)
    {
    }

    public async Task<User> GetUserByCredintial(string userName, string password)
    {
        return await dbContext.Users
            .FirstAsync(c => c.UserName == userName && c.Password == password);
    }
}
