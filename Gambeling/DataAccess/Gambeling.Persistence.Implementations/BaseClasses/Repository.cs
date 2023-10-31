using Gambeling.Persistence.Implementations.Context;

namespace Gambeling.Persistence.Implementations.BaseClasses;

public class Repository
{
    protected readonly IGambelingDbContext dbContext;

    public Repository(IGambelingDbContext DBContex)
     => dbContext = DBContex;

    public void SaveChanges()
    {
    }
}
