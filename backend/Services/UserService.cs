using Models.Interfaces;
using Models;
using Services.Shared;

namespace Services;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository) =>
        _userRepository = userRepository;

    public async Task CreateUser(string firstName, string lastName, string email, string password)
    {
        var user = new User()
        {
            Id = Guid.NewGuid(),
            FirstName = firstName,
            LastName = lastName,    
            Email = email,
            IsEmployee = false,
            Password = password.Encrypt(),
        };
        await _userRepository.AddAsync(user);
    }


}
