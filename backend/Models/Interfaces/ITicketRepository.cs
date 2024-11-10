using Models;
namespace Data.Repositories;

public interface ITicketRepository
{
    Task<Ticket> GetByIdAsync(string id);
    Task AddAsync(Ticket ticket);
    Task UpdateAsync(Ticket ticket);
    Task DeleteAsync(string id);
    Task<IEnumerable<Ticket>> GetAllAsync();
}
