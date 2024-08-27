using FinSpotAPI.Common.Enumerations;
using FinSpotAPI.Domain.Models.Users;

namespace FinSpotAPI.Domain.Models.Operations
{
    public class Operation
    {
        public required int Id { get; set; }

        public required string Name { get; set; }

        public required DateTime DateTime { get; set; }

        public required OperationType Type { get; set; }

        public required decimal Amount { get; set; }

        public required Currency Currency { get; set; }

        public required ExpenseCategory ExpenseCategory { get; set; }

        public string? Details { get; set; }


        public required int UserId { get; set; }
        public required User User { get; set; }
    }
}
