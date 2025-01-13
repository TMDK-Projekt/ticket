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

    [HttpPost("createTicket")]
    public async Task<IActionResult> CreateTicket([FromBody] CreateTicketDto dto)
    {
        await _ticketService.CreateTicketAsync(dto);
        return Ok();
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
