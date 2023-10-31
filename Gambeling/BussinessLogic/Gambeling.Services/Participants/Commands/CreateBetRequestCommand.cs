using Gambeling.DomainModels.Participants;
using Infrastracture.Commands;
using Infrastracture.Exceptions;

namespace Gambeling.Services.Participants.Commands;

public record CreateBetRequestCommand(Guid ParticipantId, int Points, int Number) : ICommand<Participant>
{
    public static CreateBetRequestCommand Create(Guid ParticipantId, int Points, int Number)
    {
        if (ParticipantId == default)
            throw new MissingRequiredPropertyException("ParticipantId must be not null and empty.");

        if (Points <= 0)
            throw new ValueLessThanZeroException("Points must be not less than or equal zero.");

        if (Number <= 0 || Number > 9)
            throw new ValueOutOfRangeException("Number must be not negative and not greater than 9.");

        return new CreateBetRequestCommand(ParticipantId, Points, Number);
    }
}
