using Gambeling.DomainModels.Participants;
using Gambeling.Persistence.Implementations.BaseClasses;
using Gambeling.Persistence.Implementations.Context;
using Gambeling.Persistence.Services.Participants;
using Microsoft.EntityFrameworkCore;

namespace Gambeling.Persistence.Implementations.Participants;

public class ParticipantsRepository : Repository, IParticipantsRepository
{
    public ParticipantsRepository(IGambelingDbContext DBContex) : base(DBContex)
    {
    }

    public async Task<Participant> GetParticipantById(Guid Id)
    {
        return await dbContext.Participants
            .Include(c => c.BetRequests)
            .FirstAsync(c => c.Id == Id);
    }

    public async Task UpdateParticipant(Participant participant)
    {
        dbContext.Participants.Update(participant);
        await dbContext.SaveChange();
    }
}
