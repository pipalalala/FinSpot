namespace FinSpotAPI.Common.Exceptions
{
    public class AuthenticationException : BaseApplicationException
    {
        public AuthenticationException(string message, string? details = null)
            : base(message, details)
        { }

        public AuthenticationException(string message, Exception innerException, string? details = null)
            : base(message, innerException, details)
        { }
    }
}
