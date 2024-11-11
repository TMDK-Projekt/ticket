using Models;
namespace Data.Repositories;

public interface ITicketRepository
{
    Task<Ticket> GetByIdAsync(int id);
    Task AddAsync(Ticket ticket);
    Task UpdateAsync(Ticket ticket);
    Task DeleteAsync(int id);
    Task<IEnumerable<Ticket>> GetAllAsync();
}
