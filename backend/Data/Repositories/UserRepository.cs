using Data;
using Data.Repositories;
using Microsoft.Extensions.Logging;
namespace Models.Interfaces;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    private readonly ILogger<UserRepository> _logger;

    public async Task AddAsync(User user)
    {
        _context.Add( user );
        _context.SaveChanges();
        _logger.LogInformation( $"Ticket with ID: {user.Id} Successfully Created" );
        await Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }
}
