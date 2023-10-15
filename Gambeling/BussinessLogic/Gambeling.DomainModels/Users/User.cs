using Infrastracture.DomainModels;

namespace Gambeling.DomainModels.Users;

public class User : Entity
{
    public string UserName { get; private set; }

    public string Password { get; private set; }

    public string Email { get; private set; }

    public DateTime CreatedDate { get; private set; }
}
