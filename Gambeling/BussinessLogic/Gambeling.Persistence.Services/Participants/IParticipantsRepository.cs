using Gambeling.DomainModels.Participants;

namespace Gambeling.Persistence.Services.Participants;

public interface IParticipantsRepository
{
    public Task<Participant> GetParticipantById(Guid Id);

    public Task UpdateParticipant(Participant participant);
}
