using Infrastracture.DomainModels;

namespace Gambeling.DomainModels.Users;

public class User : Entity
{
    public string UserName { get; private set; }

    public string Password { get; private set; }

    public string Email { get; private set; }

    public DateTime CreatedDate { get; private set; }

    User(string userName, string password, string email)
    {
        UserName = userName;
        Password = password;
        Email = email;
        CreatedDate = DateTime.Now;
    }

    public static User Create(string userName, string password, string email)
    => new(userName, password, email);
}
