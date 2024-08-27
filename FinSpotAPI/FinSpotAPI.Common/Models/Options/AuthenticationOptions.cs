namespace FinSpotAPI.Common.Models.Options
{
    public class AuthenticationOptions
    {
        public const string SectionPath = "Authentication";

        public required string Issuer { get; set; }

        public required string Audience { get; set; }

        public required int TokenLifetimeMinutes { get; set; }

        public required string IssuerSigningKeySecretName { get; set; }
    }
}
