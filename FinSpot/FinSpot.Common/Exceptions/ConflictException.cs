namespace FinSpotAPI.Common.Exceptions
{
    public class ConflictException : BaseApplicationException
    {
        public ConflictException(string message, string? details = null)
            : base(message, details)
        { }

        public ConflictException(string message, Exception innerException, string? details = null)
            : base(message, innerException, details)
        { }
    }
}
