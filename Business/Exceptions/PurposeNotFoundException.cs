namespace Business.Exceptions;

public class PurposeNotFoundException : Exception
{
    public PurposeNotFoundException(string? message) : base(message)
    {
    }
}