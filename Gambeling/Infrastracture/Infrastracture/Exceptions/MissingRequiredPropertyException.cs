namespace Infrastracture.Exceptions;

public class MissingRequiredPropertyException : Exception
{
    public MissingRequiredPropertyException(string message) : base(message)
    { }
}
