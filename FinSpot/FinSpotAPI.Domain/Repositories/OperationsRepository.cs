using FinSpotAPI.Domain.Models.Operations;
using FinSpotAPI.Domain.Repositories.Interfaces;

namespace FinSpotAPI.Domain.Repositories
{
    public class OperationsRepository : IOperationsRepository
    {
        private readonly FinSpotContext _context;

        public OperationsRepository(FinSpotContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Operation> AddAsync(Operation operation)
        {
            ArgumentNullException.ThrowIfNull(operation, nameof(operation));

            await _context.AddAsync(operation);
            await _context.SaveChangesAsync();

            return operation;
        }
    }
}
