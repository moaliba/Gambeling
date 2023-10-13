using Infrastracture.DomainModels;

namespace Gambeling.DomainModels.Participants;

public class Participant : Entity
{
    public string Name { get; private set; }

    public string SurName { get; private set; }

    public string SocialSecurityNumber { get; private set; }

    public ParticipantAccount Account { get; private set; }

    public ICollection<BetRequest> BetRequests { get; private set; }

    public Participant()
    {
        BetRequests = new List<BetRequest>();
    }

    public void AddBetRequest(int points, int number)
    {
        Account.CurrentAccount += points;
        CreateRequest(points, number);
    }

    void CreateRequest(int points, int number)
    {
        BetRequests.Add(BetRequest.Create(Id, Account.CurrentAccount, points, number));
    }
}
