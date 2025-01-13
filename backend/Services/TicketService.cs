using Models;
using Models.Interfaces;
using Services.Dto;

namespace Services;
public class TicketService
{
    private readonly ITicketRepository _ticketRepository;

    public TicketService(ITicketRepository ticketRepository) =>
        _ticketRepository = ticketRepository;

    public async Task CreateTicketAsync(TicketDto dto)
    {
        var ticket = new Ticket
        {
            Id = new Guid(),
            CustomerId = dto.CustomerId,
            Reason = dto.Reason,
            Status = Status.Unassigned,
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

    public async Task<IEnumerable<Ticket>> GetTicketTree(Guid ticketId, Guid customerId)
    {
        return await _ticketRepository.GetTicketTree(ticketId,customerId);
    }
}

