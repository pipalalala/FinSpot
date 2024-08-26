using FinSpotAPI.Common.Exceptions;
using FinSpotAPI.Domain.Models.Operations;
using FinSpotAPI.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<Operation>> GetByUserIdAsync(int userId)
        {
            return await _context.Operations
                .Where(_ => _.UserId == userId)
                .ToListAsync();
        }

        public async Task<Operation> UpdateAsync(int userId, Operation operation)
        {
            var operationToUpdate = await _context.Operations
                .FirstOrDefaultAsync(_ => _.UserId == userId && _.Id == operation.Id)
                    ?? throw new NotFoundException($"Operation with ID `{operation.Id}` does not exist.");

            operationToUpdate.Name = operation.Name;
            operationToUpdate.DateTime = operation.DateTime;
            operationToUpdate.Type = operation.Type;
            operationToUpdate.Amount = operation.Amount;
            operationToUpdate.Currency = operation.Currency;
            operationToUpdate.ExpenseCategory = operation.ExpenseCategory;
            operationToUpdate.Details = operation.Details;

            await _context.SaveChangesAsync();

            return operationToUpdate;
        }

        public async Task DeleteAsync(int userId, int id)
        {
            var operation = await _context.Operations.FirstOrDefaultAsync(_ => _.Id == id && _.UserId == userId)
                ?? throw new NotFoundException($"Operation with ID `{id}` does not exist.");

            _context.Operations.Remove(operation);

            await _context.SaveChangesAsync();
        }
    }
}
