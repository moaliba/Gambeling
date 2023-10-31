using Gambeling.DomainModels.Users;
using Gambeling.Persistence.Services.Users;
using Gambeling.Services.Implementations.Token;
using Gambeling.Services.Users.Queries;
using Infrastracture.Exceptions;
using Infrastracture.Queries;

namespace Gambeling.Services.Implementations.Users.Queries;

public class GetTokenByCredentialQueryHandler : IQueryHandler<GetTokenByCredentialQuery, string>
{
    private readonly IUsersRepository _usersRepository;
    private readonly ITokenService _tokenService;

    private GetTokenByCredentialQuery _query;

    public GetTokenByCredentialQueryHandler(
        IUsersRepository usersRepository, ITokenService tokenService)
    {
        _usersRepository = usersRepository;
        _tokenService = tokenService;
    }

    public async Task<string> HandelAsync(GetTokenByCredentialQuery query)
    {
        _query = query ?? throw new ArgumentNullException(nameof(query));
        User user = await GetUserAsync();
        string token = await _tokenService.CreateToken(user);
        return token;
    }

    private async Task<User> GetUserAsync()
    {
        User user = await _usersRepository.GetUserByCredintial(
            _query.userName, _query.password);
        if (user == default)
            throw new EntityNotFoundException(
                $"User was not found.");
        else
            return user;
    }
}
