using Models;

namespace Data.Repositories;

public interface IUserRepository
{
    Task<User> GetByIdAsync(string id);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(string id);
    Task<IEnumerable<User>> GetAllAsync();
}
