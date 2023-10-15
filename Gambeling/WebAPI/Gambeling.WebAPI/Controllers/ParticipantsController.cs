using Gambeling.DomainModels.Participants;
using Gambeling.Services.Participants.Commands;
using Gambeling.WebAPI.DataTransfering.Dtos;
using Gambeling.WebAPI.DataTransfering.ViewModels;
using Infrastracture.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Gambeling.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ParticipantsController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> ApproveIdentityVerificationAsync(
        Guid ParticipantId,
        [FromBody] BetRequestDto betRequestDto,
        [FromServices] ICommandHandler<CreateBetRequestCommand, Participant> commandHandler)
        {
            if (betRequestDto == null)
                throw new ArgumentNullException(nameof(betRequestDto));
            Participant participant = await commandHandler.HandleAsync(
                CreateBetRequestCommand.Create(
                    ParticipantId, betRequestDto.Points, betRequestDto.Number));
            BetRequest betRequest = participant.BetRequests.OrderBy(c => c.RequestDate).Last();
            BetRequestViewModel betRequestViewModel = new()
            {
                Account = participant.Account.CurrentAccount,
                ParticipantId = participant.Id,
                Points = betRequest.Points.ToString(),
                Status = betRequest.Status.ToString()
            };
            return Ok(JsonConvert.SerializeObject(betRequestViewModel));
        }
    }
}
