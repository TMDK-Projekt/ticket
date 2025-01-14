using Models;
using Models.Interfaces;
using Services.Dto;

namespace Services;
public class TicketService
{
    private readonly ITicketRepository _ticketRepository;
    private readonly AIService _aIService;

    public TicketService(ITicketRepository ticketRepository, AIService aIService)
    {
        _ticketRepository = ticketRepository;
        _aIService = aIService;
    }

    public async Task CreateTicketAsync(TicketDto dto)
    {
        var ticket = new Ticket
        {
            Id = new Guid(),
            CustomerId = dto.CustomerId,
            Reason = dto.Reason,
            Status = Status.Unassigned,
            Description = dto.Description,
            CreatedDate = DateTime.Now
        };

        await _ticketRepository.AddAsync(ticket);
    }

    public async Task CreateAttachedTicketAsync(TicketDto dto )
    {
        var ticket = new Ticket
        {
            Id = new Guid(),
            CustomerId = dto.CustomerId,
            EmployeeId = dto.EmployeeId,
            Reason = dto.Reason,
            Status = Status.Assigned,
            Description = dto.Description,
            CreatedDate = DateTime.Now
        };

        await _ticketRepository.AddAsync(ticket);

        await _ticketRepository.UpdateRelatedTicketIdAsync(dto.Id, ticket.Id);
    }

    public async Task<Ticket?> GetTicketByIdAsync(Guid id)
    {
        return await _ticketRepository.GetByIdAsync(id);
    }

    public async Task UpdateDescriptionAsync(Ticket ticket)
    {
        await _ticketRepository.UpdateDescriptionAsync(ticket);
    }

    public async Task UpdateStatusAsync( Ticket ticket, Status newStatus )
    {
        await _ticketRepository.UpdateStatusAsync( ticket, newStatus );
    }

    public async Task DeleteAsync(Guid id)
    {
        await _ticketRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<Ticket>> GetAllAsync()
    {
        return await _ticketRepository.GetAllAsync();
    }

    public async Task<IEnumerable<Ticket>> GetRelatedTicketTree(Guid ticketId, Guid customerId)
    {
        return await _ticketRepository.GetRelatedTicketTree(ticketId,customerId);
    }
    public async Task AssignAsync(TicketDto dto)
    {
        await _ticketRepository.AssignAsync(dto.Id,dto.EmployeeId);
    }

    public async Task<string?> GenerateTicketResponse(string prompt)
    {
        return await _aIService.CallOpenAIAsync(prompt) ?? throw new Exception("API Response cant be null");
    }
}

