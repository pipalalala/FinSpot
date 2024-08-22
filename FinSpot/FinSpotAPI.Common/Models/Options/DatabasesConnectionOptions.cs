namespace FinSpotAPI.Common.Models.Options
{
    public class DatabasesConnectionOptions
    {
        public const string SectionPath = "DatabasesConnection";

        public required string FinSpotPostgresSecretName { get; set; }
    }
}
