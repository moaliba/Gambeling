using Infrastracture.Exceptions;
using Infrastracture.Queries;

namespace Gambeling.Services.Users.Queries;

public record GetTokenByCredentialQuery(string userName, string password) : IQuery<string>
{
    public static GetTokenByCredentialQuery Create(string userName, string password)
    {
        if (string.IsNullOrWhiteSpace(userName))
            throw new MissingRequiredPropertyException("UserName must be not null and empty.");

        if (string.IsNullOrWhiteSpace(password))
            throw new MissingRequiredPropertyException("Password must be not null and empty.");

        return new GetTokenByCredentialQuery(userName, password);
    }
}
