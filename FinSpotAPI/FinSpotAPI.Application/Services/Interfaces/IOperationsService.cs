using FinSpotAPI.Application.Models.Operations;

namespace FinSpotAPI.Application.Services.Interfaces
{
    public interface IOperationsService
    {
        Task<OperationModel> AddAsync(OperationCreateModel operationCreateModel);

        Task<IEnumerable<OperationModel>> GetByUserIdAsync();

        Task<OperationModel> UpdateAsync(OperationUpdateModel operationUpdateModel);

        Task DeleteAsync(int id);
    }
}
