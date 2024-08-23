using FinSpotAPI.Common.Enumerations;

namespace FinSpotAPI.Domain.Models.Users
{
    public class BankingCard
    {
        public required int Id { get; set; }

        public required string Number { get; set; }

        public required Currency Сurrency { get; set; }

        public int? ExpiresMonth { get; set; }

        public int? ExpiresYear { get; set; }

        public BankingCardType? Type { get; set; }

        public string? Details { get; set; }

        public required int UserId { get; set; }
    }
}
