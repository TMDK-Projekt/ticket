namespace Models;

public class TicketRelationship
{
    public int InitialTicketId { get; set; }
    public int RelatedTicketId { get; set; }
    public string? RelationshipDescription { get; set; }
}
