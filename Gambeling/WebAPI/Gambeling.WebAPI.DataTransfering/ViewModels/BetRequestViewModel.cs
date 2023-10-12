namespace Gambeling.WebAPI.DataTransfering.ViewModels;

public class BetRequestViewModel
{
    public Guid ParticipantId { get; set; }

    public int Account { get; set; }

    public string Status { get; set; }

    public string Points { get; set; }
}
