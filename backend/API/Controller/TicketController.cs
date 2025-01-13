using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Dto;

namespace API.Controller;

[Route("api/ticket")]
[ApiController]
public class TicketController : ControllerBase
{
    private readonly TicketService _ticketService;

    public TicketController(TicketService ticketService)
    {
        _ticketService = ticketService;
    }

    [HttpGet("getTicket/{id}")]
    public async Task<IActionResult> GetTicket(Guid id)
    {
        var ticket = await _ticketService.GetTicketByIdAsync(id);
        return Ok(ticket);
    }

    [HttpGet("getAllTickets")]
    public async Task<IActionResult> GetAllTickets()
    {
        var tickets = await _ticketService.GetAllAsync();
        return Ok(tickets);
    }

    [HttpPost("assignTicket")]
    public async Task<IActionResult> AssignTicket( [FromBody] TicketDto dto)
    {
        await _ticketService.AssignAsync(dto.Id, dto.EmployeeId);
        return Ok();
    }

    // POST api/<TicketController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
        var tickets = await _ticketService.GetTicketTree(dto.Id, dto.CustomerId);
        return Ok(tickets);
    }

    [HttpPost("createTicket")]
    public async Task<IActionResult> CreateTicket([FromBody] TicketDto dto)
    {
        await _ticketService.CreateTicketAsync(dto);
        return Ok();
    }
}
