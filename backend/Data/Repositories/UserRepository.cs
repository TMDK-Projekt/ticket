using Data;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace Models.Interfaces;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    private readonly ILogger<UserRepository> _logger;


    public UserRepository(AppDbContext context, ILogger<UserRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task AddAsync(User user)
    {
        _context.Add(user);
        _context.SaveChanges();
        _logger.LogInformation($"User with ID: {user.Id} Successfully Created");
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = _context.Users.Where(user => user.Id == id);

        if (user == null)
        {
            _logger.LogError($"User with ID: {id} Not Found");
            return;
        }

        _context.Remove(user);
        _logger.LogInformation($"User with ID: {id} Successfully Deleted");
        await _context.SaveChangesAsync();
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

        if (user == null)
        {
            _logger.LogError($"User with ID: {id} not found.");
            return null;
        }

        return user;
    }

    public Task UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }
}
