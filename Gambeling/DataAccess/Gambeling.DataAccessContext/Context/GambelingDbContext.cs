using Gambeling.DataAccessContext.Mapping;
using Gambeling.DomainModels.Participants;
using Gambeling.Persistence.Implementations.Context;
using Microsoft.EntityFrameworkCore;

namespace Gambeling.DataAccessContext.Context;

public class GambelingDbContext : DbContext, IGambelingDbContext
{
    public DbSet<Participant> Participants { get; set; }
    public DbSet<BetRequest> BetRequests { get; set; }

    public GambelingDbContext(DbContextOptions<GambelingDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new ParticipantMapping());
        builder.ApplyConfiguration(new ParticipantMapping());
    }

    public async Task<int> SaveChange()
    {
        return await base.SaveChangesAsync();
    }
}
