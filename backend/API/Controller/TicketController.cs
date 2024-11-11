using Microsoft.AspNetCore.Mvc;
using Services;

namespace API.Controller;

[Route("api/ticket")]
[ApiController]
public class TicketController : ControllerBase
{
    private readonly TicketService _ticketService;

    public TicketController(TicketService ticketService)
        => _ticketService = ticketService;

    // GET: api/<TicketController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    [HttpGet("getTicket/{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var ticket = await _ticketService.GetTicketByIdAsync(id);
        return Ok(ticket);
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
