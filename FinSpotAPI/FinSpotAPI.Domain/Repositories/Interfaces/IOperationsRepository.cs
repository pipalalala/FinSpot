using FinSpotAPI.Domain.Models.Operations;

namespace FinSpotAPI.Domain.Repositories.Interfaces
{
    public interface IOperationsRepository
    {
        Task<Operation> AddAsync(Operation operation);

        Task<IEnumerable<Operation>> GetByUserIdAsync(int userId);

        Task<Operation> UpdateAsync(int userId, Operation operation);

        Task DeleteAsync(int userId, int id);
    }
}
