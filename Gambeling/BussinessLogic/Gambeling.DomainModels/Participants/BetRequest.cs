using System.ComponentModel.DataAnnotations;

namespace Gambeling.DomainModels.Participants;

public class BetRequest
{
    [Key]
    public Guid Id { get; private set; }

    public Guid ParticipantId { get; private set; }

    public int Account { get; private set; }

    public int Points { get; private set; }

    public int Number { get; private set; }

    public Status Status { get; private set; }

    public DateTime RequestDate { get; private set; }

    public BetRequest(
        Guid id,
        Guid participantId,
        int account,
        int points,
        int number,
        Status status,
        DateTime requestDate)
    {
        Id = id;
        ParticipantId = participantId;
        Account = account;
        Points = points;
        Number = number;
        Status = status;
        RequestDate = requestDate;
    }

    public static BetRequest Create(Guid participantId, int account, int points, int number)
    {
        Status status = Status.Won;
        if (points < 0) status = Status.Lost;
        return new(Guid.NewGuid(), participantId, account, points, number, status, DateTime.UtcNow);
    }
}
