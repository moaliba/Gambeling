using Gambeling.DomainModels.Participants;
using Gambeling.Persistence.Services.Participants;
using Gambeling.Services.Participants.Commands;
using Infrastracture.Commands;
using Infrastracture.Exceptions;

namespace Gambeling.Services.Implementations.BetRequests.Commands;

public class CreateBetRequestCommandHandler : ICommandHandler<CreateBetRequestCommand, Participant>
{
    private readonly IParticipantsRepository _participantsRepository;

    private CreateBetRequestCommand _command;

    public CreateBetRequestCommandHandler(IParticipantsRepository participantsRepository)
    => _participantsRepository = participantsRepository;

    public async Task<Participant> HandleAsync(CreateBetRequestCommand command)
    {
        _command = command ?? throw new ArgumentNullException(nameof(command));
        Participant participant = await GetParticipantAsync();
        ValidateRequestedPoints(command, participant);
        int randomNumber = CreateRandomNumber();
        int finalPoints = ComputeFinalPoints(randomNumber);
        participant.AddBetRequest(finalPoints, _command.Number);
        await UpdateParticipantAsync(participant);

        return participant;
    }

    private async Task<Participant> GetParticipantAsync()
    {
        Participant participant = await _participantsRepository.GetParticipantById(
            _command.ParticipantId);
        if (participant == default)
            throw new EntityNotFoundException(
                $"Entity with Id {_command.ParticipantId} was not found.");
        else
            return participant;
    }

    private static void ValidateRequestedPoints(CreateBetRequestCommand command, Participant participant)
    {
        if (command.Points > participant.Account.CurrentAccount)
            throw new ValueOutOfRangeException("Points must not be greater than account.");
    }

    private static int CreateRandomNumber()
    {
        Random random = new();
        int number = random.Next(0, 10);
        return number;
    }

    private int ComputeFinalPoints(int number)
    {
        if (number == _command.Number)
            return _command.Points * 9;
        else
            return _command.Points * -1;
    }

    private async Task UpdateParticipantAsync(Participant participant)
    {
        await _participantsRepository.UpdateParticipant(participant);
    }
}
