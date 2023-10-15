using Gambeling.DomainModels.Users;

namespace Gambeling.Services.Implementations.Token;

public interface ITokenService
{
    Task<string> CreateToken(User user);
}
