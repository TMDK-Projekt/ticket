using Models;
using Models.Interfaces;

namespace Services;
public class TicketService
{
    private readonly ITicketRepository _ticketRepository;

    public TicketService(ITicketRepository ticketRepository) =>
        _ticketRepository = ticketRepository;

    public async Task CreateTicketAsync(int customerId, string reason)
    {
        var ticket = new Ticket
        {
            Id = new Guid(),
            CustomerId = new Guid(),
            Reason = reason,
            Status = Status.None,
            CreatedDate = DateTime.Now
        };

        await _ticketRepository.AddAsync(ticket);
    }

    public async Task<Ticket?> GetTicketByIdAsync(Guid id)
    {
        return await _ticketRepository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(Ticket ticket)
    {
        await _ticketRepository.UpdateAsync(ticket);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _ticketRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<Ticket>> GetAllAsync()
    {
        return await _ticketRepository.GetAllAsync();
    }
}

