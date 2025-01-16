using Models;

namespace Services.Dto;

public class TicketFilterDto
{
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public Status? Status { get; set; }
}
