namespace API.Exceptions;

public class FailedToCreateOrderException : Exception
{
    public FailedToCreateOrderException(string message) : base(message) {}
}