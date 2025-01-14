﻿using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using Services.Dto;
using Services.Shared;

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

    [HttpPost("getAllRelatedTickets")]
    public async Task<IActionResult> GetRelatedTicketTree([FromBody] TicketDto dto)
    {
        var tickets = await _ticketService.GetRelatedTicketTree(dto.Id, dto.CustomerId);
        return Ok(tickets);
    }

    [HttpPost("getGeneratedTicketResponse")]
    public async Task<IActionResult> GenerateTicketResponse([FromBody] GenerateTicketDto request)
    {
        var response = await _ticketService.GenerateTicketResponse(request.Prompt);
        return Ok(response);
    }

    [HttpPost("assignTicket")]
    public async Task<IActionResult> AssignTicket([FromBody] TicketDto dto)
    {
        var ticket = await _ticketService.AssignAsync(dto);
        return Ok(ticket);
    } 

    [HttpPost("createAttachedTicket")]
    public async Task<IActionResult> CreateAttachedTicket([FromBody] TicketDto dto)
    {
        await _ticketService.CreateAttachedTicketAsync(dto);
        return Ok();
    }

    [HttpPost("createTicket")]
    public async Task<IActionResult> CreateTicket([FromBody] TicketDto dto)
    {
        await _ticketService.CreateTicketAsync(dto);
        return Ok();
    }

    [HttpPost( "updateDescription" )]
    public async Task<IActionResult> updateDescription( [FromBody] TicketDto dto )
    {
        var ticket = await _ticketService.UpdateDescriptionAsync(dto);
        return Ok(ticket);
    }

    [HttpPost( "updateStatus" )] //we need the Status as number
    public async Task<IActionResult> updateStatus([FromBody] TicketDto dto )
    {
        var ticket = await _ticketService.UpdateStatusAsync(dto);
        return Ok(ticket);
    }
}
