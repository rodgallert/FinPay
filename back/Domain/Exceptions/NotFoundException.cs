namespace Domain.Exceptions;
public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    {
    }
    public NotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static void ThrowIfNull(object obj, string message)
    {
        if (obj == null)
            throw new NotFoundException(message);
    }
}
