namespace Infrastracture.Exceptions;

public class ValueLessThanZeroException : Exception
{
    public ValueLessThanZeroException(string message) : base(message)
    { }
}
