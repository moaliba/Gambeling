using Infrastracture.DomainModels;

namespace Gambeling.DomainModels.BetRequests;

public class BetRequest : Entity
{
    public Guid ParticipantId { get; set; }

    public int Points { get; set; }

    public int Number { get; set; }

    public Status Status { get; set; }

    public DateTime RequestDate { get; set; }
}
