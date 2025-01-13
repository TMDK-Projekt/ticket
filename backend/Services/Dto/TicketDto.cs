namespace Services.Dto;

public class TicketDto
{
    public Guid CustomerId { get; set; }
    public string Reason { get; set; } = string.Empty;
}
