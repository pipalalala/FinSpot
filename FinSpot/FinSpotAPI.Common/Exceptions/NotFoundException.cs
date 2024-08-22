namespace FinSpotAPI.Common.Exceptions
{
    public class NotFoundException : BaseApplicationException
    {
        public NotFoundException(string message, string? details = null)
            : base(message, details)
        { }

        public NotFoundException(string message, Exception innerException, string? details = null)
            : base(message, innerException, details)
        { }
    }
}
