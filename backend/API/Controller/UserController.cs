using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Dto;
using System.Runtime.CompilerServices;
namespace API.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("createUser")]
    public async Task<IActionResult> CreateUser([FromBody] UserDto dto)
    {
        await _userService.CreateUser(dto);
        return Ok();
    }

    [HttpPost("logInUser")]
    public async Task<IActionResult> LogInUser( [FromBody] UserDto dto)
    {
        var result = await _userService.GetUserAsync(dto.Email, dto.Password);
        return Ok(result);
    }

    // GET api/<UserController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<UserController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<UserController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<UserController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
