namespace FinSpotAPI.Common.Models
{
    public class ErrorResponseModel
    {
        public required string Message { get; set; }

        public string? Details { get; set; }
    }
}
