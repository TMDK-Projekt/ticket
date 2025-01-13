using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using Models.Interfaces;
using Services.Dto;

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
        _context.Add(ticket);
        _context.SaveChanges();
        _logger.LogInformation($"Ticket with ID: {ticket.Id} Successfully Created");
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

    public async Task AssignAsync( Guid ticketId, Guid userId )
    {
        var result = _context.Tickets.FirstOrDefault(x=> x.Id == ticketId); // the needed ticket
        if (result is null)
        {
            _logger.LogError( $"No Ticket with id: {ticketId} Found" );
            return;
        }

        if ( _context.Users.First(x => x.Id == userId) is null)
        {
            _logger.LogError( $"No User with id: {userId} Found" );
            return;
        }

        result.EmployeeId = userId;
        _context.SaveChanges();
        _logger.LogInformation($"Ticket with ID: {ticketId} assigned to user with ID: {userId}");
        await Task.CompletedTask;
    }
}
