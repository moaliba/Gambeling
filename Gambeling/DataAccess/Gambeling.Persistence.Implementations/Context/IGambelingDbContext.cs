using Gambeling.DomainModels.Participants;
using Microsoft.EntityFrameworkCore;

namespace Gambeling.Persistence.Implementations.Context;

public interface IGambelingDbContext
{
    public DbSet<Participant> Participants { get; set; }
    public DbSet<BetRequest> BetRequests { get; set; }
    Task<int> SaveChange();
}
