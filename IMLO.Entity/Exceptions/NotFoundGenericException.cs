namespace IMLO.Entity.Exceptions;

public class NotFoundGenericException : NotFoundException
{
    public NotFoundGenericException(string message) : base(message)
    {
    }
}