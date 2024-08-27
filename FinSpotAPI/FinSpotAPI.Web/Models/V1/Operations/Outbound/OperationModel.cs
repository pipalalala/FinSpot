using FinSpotAPI.Common.Enumerations;

namespace FinSpotAPI.Web.Models.V1.Operations.Outbound
{
    public class OperationModel
    {
        public required int Id { get; set; }

        public required string Name { get; set; }

        public required DateTime DateTime { get; set; }

        public required OperationType Type { get; set; }

        public required decimal Amount { get; set; }

        public required Currency Currency { get; set; }

        public required ExpenseCategory ExpenseCategory { get; set; }

        public string? Details { get; set; }
    }
}
