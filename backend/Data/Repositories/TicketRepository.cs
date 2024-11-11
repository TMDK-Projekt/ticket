using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using Models.Interfaces;

namespace Data.Repositories;

public class TicketRepository : ITicketRepository
{
    private readonly AppDbContext _context;
    private readonly ILogger<TicketRepository> _logger;

    public TicketRepository(AppDbContext context, ILogger<TicketRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task AddAsync(Ticket ticket)
    {
        // Hier müsste Code stehen der das ticket in die Datenbank hinzufügt

        _context.Add(ticket);
        _context.SaveChanges();
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(Guid id)
    {
        var ticket = await _context.Tickets
            .FirstOrDefaultAsync(x => x.Id == id);

        // Alle Related Tickets müssen auch noch gelöscht werden (Methode schreiben mit GetAllRelatedTickets)

        if (ticket == null)
        {
            _logger.LogError($"No Ticket with id: {id} Found");
            return;
        }

        _context.Tickets.Remove(ticket);
        _context.SaveChanges();
    }

    public async Task<IEnumerable<Ticket>> GetAllAsync()
    {
        // Alle Individuellen Tickets die kein Ticket Relationship besitzen

        var tickets = await _context.Tickets.ToListAsync();
        return tickets;
    }

    public async Task<Ticket?> GetByIdAsync(Guid id)
    {
        var ticket = await _context.Tickets
            .FirstOrDefaultAsync(x => x.Id == id);

        if (ticket is null)
        {
            _logger.LogError($"No Ticket with id: {id} Found");
            return null;
        }

        return ticket;
    }

    public Task UpdateAsync(Ticket ticket)
    {
        throw new NotImplementedException();
    }
}
