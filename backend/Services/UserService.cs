using Models.Interfaces;
using Models;
using Services.Shared;
using Services.Dto;

namespace Services;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository) =>
        _userRepository = userRepository;

    public async Task CreateUser(UserDto dto)
    {
        var user = new User()
        {
            Id = Guid.NewGuid(),
            FirstName = dto.FirstName,
            LastName = dto.LastName,    
            Email = dto.Email,
            IsEmployee = dto.IsEmployee,
            Password = dto.Password.Encrypt(),
        };
        await _userRepository.AddAsync(user);
    }

    public async Task DeleteUserById(Guid userId)
    {
        await _userRepository.DeleteAsync(userId);
    }
    
    public async Task GetUserById(Guid userId)
    {
        await _userRepository.GetByIdAsync(userId); 
    }

    public async Task UpdateUser(UserDto dto)
    {
        await _userRepository.UpdateAsync(new User
        {
            Id = dto.Id,
            FirstName = dto.FirstName ?? string.Empty,
            LastName = dto.LastName ?? string.Empty,
            Password = dto.Password != null ? dto.Password.Encrypt() : string.Empty,
            Email = dto.Email ?? string.Empty,
        });
    }
}
