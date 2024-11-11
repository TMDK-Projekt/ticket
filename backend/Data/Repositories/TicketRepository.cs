using Microsoft.EntityFrameworkCore;
using Models;

namespace Data.Repositories;

public class TicketRepository : ITicketRepository
{
    private readonly AppDbContext _context;

    public TicketRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Ticket ticket)
    {
        // Hier müsste Code stehen der das ticket in die Datenbank hinzufügt
        // z.B
        _context.Add(ticket);
        _context.SaveChanges();
        await Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Ticket>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Ticket> GetByIdAsync(int id)
    {
        var ticket = await _context.Tickets
            .FirstOrDefaultAsync(x => x.Id == id);

        if (ticket is null)
        {
            throw new ArgumentException($"No Ticket with id: {id} Found");
        }

        return ticket;
    }

    public Task UpdateAsync(Ticket ticket)
    {
        throw new NotImplementedException();
    }
}
