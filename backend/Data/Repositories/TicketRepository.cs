﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using Models.Interfaces;
using Services.Shared;

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
    // TODO: Absprechen inwiefern es erlaubt wird ein Ticket zu löschen, und ob es überhaupt nötig ist den Ticket tree zu entfernen???
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

    public async Task<IEnumerable<Ticket>> GetRelatedTicketTree(Guid ticketId, Guid customerId)
    {
        var allUserTickets = await _context.Tickets
            .Where(ticket => ticket.CustomerId == customerId)
            .ToListAsync();

        var startTicket = allUserTickets.FirstOrDefault(ticket => ticket.Id == ticketId);

        if (startTicket == null)
        {
            _logger.LogError($"Ticket with ID: {ticketId} not found for customer with ID: {customerId}");
            return [];
        }

        var relatedTicketTree = RelatedTicketUtills.BuildTicketTree(startTicket, allUserTickets);
        return relatedTicketTree.OrderByDescending(ticket => ticket.CreatedDate);
    }

    public async Task<IEnumerable<Ticket>> GetAllAsync()
    {
        return await _context.Tickets
            .Where(x => x.RelatedTicketId == Guid.Empty)
            .OrderByDescending(ticket => ticket.CreatedDate)
            .ToListAsync();
    }
    public async Task<IEnumerable<Ticket>> GetAllFilteredAsync(Status status)
    {
        return await _context.Tickets
            .Where( x => x.RelatedTicketId == Guid.Empty && x.Status == status)
            .OrderByDescending( ticket => ticket.CreatedDate )
            .ToListAsync();
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

    public async Task UpdateRelatedTicketIdAsync( Guid initialTicketId, Guid attachedTicketId )
    {
        var initialTicket = await _context.Tickets.FirstOrDefaultAsync(x => x.Id == initialTicketId);
        if (initialTicket is null )
        {
            _logger.LogInformation( $"Ticket with ID: {initialTicketId} could not be found" );
            return;
        }
        initialTicket.RelatedTicketId = attachedTicketId;
        _context.SaveChanges();
        _logger.LogInformation( $"Ticket with ID: {attachedTicketId} was referenced in ticket with ID: {initialTicketId}" );
        await Task.CompletedTask;
    }

    public async Task<Ticket?> UpdateDescriptionAsync(Guid ticketId, string newDescription)
    {
        //Wenn Ticket Related Id hat dann darf es nicht geupdated werden
        //Wenn Ticket Employee Id hat dann darf es nicht geupdated werden

        var ticketToUpdate = await _context.Tickets
           .FirstOrDefaultAsync(x => x.Id == ticketId);

        if (ticketToUpdate is null)
        {
            _logger.LogError($"No Ticket with id: {ticketId} Found");
            return null;
        }

        if (ticketToUpdate.RelatedTicketId != Guid.Empty || ticketToUpdate.EmployeeId != Guid.Empty)
        {
            _logger.LogError($"Cant Update Ticket because it either has " +
                $"a Related ticket or is already assinged to an Employee");
            return null;
        }

        ticketToUpdate.Description = newDescription;
        _context.SaveChanges();
        return ticketToUpdate;
            }

    public async Task<Ticket?> UpdateStatusAsync( Guid ticketId, Status newStatus )
    {
        var ticketToUpdate = await _context.Tickets
           .FirstOrDefaultAsync( x => x.Id == ticketId );

        if ( ticketToUpdate is null )
        {
            _logger.LogError( $"No Ticket with id: {ticketId} Found" );
            return null;
        }

        if ( !Enum.IsDefined( typeof( Status ), newStatus ) )
        {
            _logger.LogError( $"Status: {newStatus} is invalid" );
            return null;
        }

        ticketToUpdate.Status = newStatus;
        _context.SaveChanges();
        return ticketToUpdate;
    }

    public async Task<Ticket?> AssignAsync( Guid ticketId, Guid userId )
    {
        var ticket = await _context.Tickets.FirstOrDefaultAsync(x=> x.Id == ticketId); // the needed ticket

        if (ticket is null)
        {
            _logger.LogError( $"No Ticket with id: {ticketId} Found" );
            return null;
        }

        if ( _context.Users.First(x => x.Id == userId) is null)
        {
            _logger.LogError( $"No User with id: {userId} Found" );
            return null;
        }

        ticket.EmployeeId = userId;
        ticket.Status = Status.Assigned;
        _context.SaveChanges();
        _logger.LogInformation($"Ticket with ID: {ticketId} assigned to user with ID: {userId}");
        return ticket;
    }

    public async Task<Ticket?> SetTicketResponse( Guid ticketId, string response )
    {
        var ticket = await _context.Tickets.FirstOrDefaultAsync( x => x.Id == ticketId ); // the needed ticket

        if ( ticket is null )
        {
            _logger.LogError( $"No Ticket with id: {ticketId} Found" );
            return null;
        }

        ticket.Response = response;
        _context.SaveChanges();
        _logger.LogInformation( $"Ticket with ID: {ticketId} has answer: {response}" );
        return ticket;
    }
}
