using FinSpotAPI.Domain.Models.Operations;

namespace FinSpotAPI.Domain.Repositories.Interfaces
{
    public interface IOperationsRepository
    {
        Task<Operation> AddAsync(Operation operation);
    }
}
