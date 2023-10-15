using Gambeling.DomainModels.Participants;
using Gambeling.DomainModels.Users;
using Microsoft.EntityFrameworkCore;

namespace Gambeling.Persistence.Implementations.Context;

public interface IGambelingDbContext
{
    public DbSet<Participant> Participants { get; set; }
    public DbSet<BetRequest> BetRequests { get; set; }
    public DbSet<User> Users { get; set; }
    Task<int> SaveChange();
}
