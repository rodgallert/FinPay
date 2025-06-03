namespace Domain.Exceptions;
public class UnprocessableRequestException(string message) : Exception(message)
{
}
