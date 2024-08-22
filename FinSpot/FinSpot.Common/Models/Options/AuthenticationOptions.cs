namespace FinSpotAPI.Common.Models.Options
{
    public class AuthenticationOptions
    {
        public const string SectionPath = "Authentication";

        public required string IssuerSecretName { get; set; }

        public required string AudienceSecretName { get; set; }

        public required string IssuerSigningKeySecretName { get; set; }

        public required string TokenLifetimeSecretName { get; set; }
    }
}
