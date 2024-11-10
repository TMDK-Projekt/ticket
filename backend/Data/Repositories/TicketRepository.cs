using Models;

namespace Data.Repositories;

public class TicketRepository : ITicketRepository
{
    private readonly AppDbContext _context;

    public async Task AddAsync(Ticket ticket)
    {
        // Hier müsste Code stehen der das ticket in die Datenbank hinzufügt
        // z.B
        _context.Add(ticket);
        _context.SaveChanges();
        await Task.CompletedTask;
    }

    public Task DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Ticket>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Ticket> GetByIdAsync(string id)
    {
        // Created Random ticket as a Mock
        var ticket = new Ticket()
        {
            Id = 1,
            CustomerId = 1,
            EmployeeId = 12,
            CreatedDate = DateTime.Now,
            Description = "Mock",
            Reason = "Reason",
            RelatedTickets = [
                new TicketRelationship(){
                   RelatedTicketId = 2,
                   RelationshipDescription = "Test Relationsship",
               }
                ],
            Status = Status.None,
        };
        await Task.CompletedTask;
        return ticket;
    }

    public Task UpdateAsync(Ticket ticket)
    {
        throw new NotImplementedException();
    }
}
