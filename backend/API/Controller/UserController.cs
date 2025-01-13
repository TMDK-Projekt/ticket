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
    [HttpPost("updateUser")]
    public async Task<IActionResult> UpdateUser([FromBody] UserDto dto)
    {
        await _userService.UpdateUser(dto);
        return Ok();
    }

    [HttpGet("deleteUser/{id}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        await _userService.DeleteUserById(id);
        return Ok();
    }

    [HttpGet("getUser/{id}")]
    public async Task<IActionResult> GetUser(Guid id)
    {
        await _userService.GetUserById(id);
        return Ok();
    }

    [HttpGet("getUserName/{id}")]
    public async Task<IActionResult> GetUserName(Guid id)
    {
        var result = await _userService.GetUserNameById(id);
        return Ok(new
        {
            result.Value.FirstName,
            result.Value.LastName
        });
    }
}
