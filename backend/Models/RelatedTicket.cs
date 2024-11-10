namespace Models;

public class TicketRelationship
{
    public int TicketId { get; set; }
    public Ticket Ticket { get; set; } = new Ticket(); 

    public int RelatedTicketId { get; set; }
    public Ticket RelatedTicket { get; set; } = new Ticket(); 

    public string? RelationshipDescription { get; set; }
}
