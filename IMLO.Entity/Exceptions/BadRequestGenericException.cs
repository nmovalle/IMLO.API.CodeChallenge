namespace IMLO.Entity.Exceptions;

public class BadRequestGenericException : BadRequestException
{
    public BadRequestGenericException(string message) : base(message) { }
}