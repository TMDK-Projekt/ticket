using Models;

namespace Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public Task AddAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }
}
