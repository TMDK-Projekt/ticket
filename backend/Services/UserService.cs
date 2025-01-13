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

    public async Task CreateUser(CreateUserDto dto)
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


}
