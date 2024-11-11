using Models.Interfaces;
using Models;

namespace Services;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository) =>
        _userRepository = userRepository;

    public async Task CreateUser()
    {
        var user = new User();
        await _userRepository.AddAsync(user);
    }
}
