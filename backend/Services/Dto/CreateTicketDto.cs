namespace Services.Dto;

public class CreateTicketDto
{
    public Guid CustomerId { get; set; }
    public string Reason { get; set; } = string.Empty;
}
