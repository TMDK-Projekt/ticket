using Models;

namespace Services.Dto;

public class TicketDto
{
    public Guid Id { get; set; }
    public Guid RelatedTicketId { get; set; }
    public Guid CustomerId { get; set; }
    public Guid EmployeeId { get; set; }
    public DateTime CreatedTime { get; set; }
    public Status Status { get; set; }
    public string Reason { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Response { get; set; } = string.Empty;
}
