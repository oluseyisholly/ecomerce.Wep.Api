namespace EcommerceWebApi.Exceptions
{
    public abstract class AppException(string message, int statusCode = 500) : Exception(message)
    {
        public int StatusCode { get; } = statusCode;
    }

    public class NotFoundException : AppException
    {
        public NotFoundException(string message = "Resource not found.")
            : base(message, 404) { }
    }

    public class BadRequestException(string message = "Bad request.")
        : AppException(message, 400) { }

    public class UnauthorizedException : AppException
    {
        public UnauthorizedException(string message = "Unauthorized.")
            : base(message, 401) { }
    }
}
