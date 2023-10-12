using Infrastracture.DomainModels;

namespace Gambeling.DomainModels.Participants;

public class Participant : Entity
{
    public string Name { get; set; }

    public string SurName { get; set; }

    public string SocialSecurityNumber { get; set; }

    public ParticipantAccount Account { get; set; }
}
