namespace Models.Interfaces;

public interface ITicketRepository
{
    Task<Ticket?> GetByIdAsync(Guid id);
    Task AddAsync(Ticket ticket);
    Task UpdateRelatedTicketIdAsync(Guid initialTicketId, Guid attachedTicketId);
    Task<Ticket?> UpdateDescriptionAsync(Guid ticketId, string newDescription);
    Task<Ticket?> UpdateStatusAsync( Guid ticketId, Status newStatus );
    Task DeleteAsync(Guid id);
    Task<IEnumerable<Ticket>> GetAllAsync();
    Task<IEnumerable<Ticket>> GetAllFilteredAsync(Status status);
    Task<Ticket?> SetTicketResponse(Guid id, string response);
    Task<Ticket?> AssignAsync( Guid ticketId, Guid userId );
    Task<IEnumerable<Ticket>> GetRelatedTicketTree(Guid ticketid, Guid customeriD);
}
