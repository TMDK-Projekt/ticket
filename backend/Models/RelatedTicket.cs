namespace Models;

public class TicketRelationship
{
    public int TicketId { get; set; }
    public int RelatedTicketId { get; set; }
    public string? RelationshipDescription { get; set; }
}
