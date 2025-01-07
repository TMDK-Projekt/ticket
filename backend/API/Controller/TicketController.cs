using Microsoft.AspNetCore.Mvc;
using Services;

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

    [HttpPost("createTicket")]
    public async Task<IActionResult> CreateTicket([FromBody] CreateTicketRequest request)
    {
        await _ticketService.CreateTicketAsync(request.CustomerId, request.Reason);
        return Ok();
    }

    public class CreateTicketRequest
    {
        public Guid CustomerId { get; set; }
        public string Reason { get; set; } = string.Empty;
    }

    // POST api/<TicketController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<TicketController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<TicketController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
