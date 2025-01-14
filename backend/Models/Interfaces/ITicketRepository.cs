namespace Models.Interfaces;

public interface ITicketRepository
{
    Task<Ticket?> GetByIdAsync(Guid id);
    Task AddAsync(Ticket ticket);
    Task UpdateRelatedTicketIdAsync(Guid initialTicketId, Guid attachedTicketId);
    Task UpdateDescriptionAsync(Ticket ticket);
    Task UpdateStatusAsync( Ticket ticket, Status newStatus );
    Task DeleteAsync(Guid id);
    Task<IEnumerable<Ticket>> GetAllAsync();
    Task AssignAsync( Guid ticketId, Guid userId );
    Task<IEnumerable<Ticket>> GetRelatedTicketTree(Guid ticketid, Guid customeriD);
}
