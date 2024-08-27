namespace FinSpotAPI.Common.Exceptions
{
    public abstract class BaseApplicationException : ApplicationException
    {
        public string? Details { get; }

        protected BaseApplicationException(string message, string? details = null)
            : base(message)
        {
            Details = details;
        }

        protected BaseApplicationException(string message, Exception innerException, string? details = null)
            : base(message, innerException)
        {
            Details = details;
        }
    }
}
