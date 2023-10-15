using Gambeling.DomainModels.Users;

namespace Gambeling.Persistence.Services.Users;

public interface IUsersRepository
{
    public Task<User> GetUserByCredintial(string userName, string password);
}
