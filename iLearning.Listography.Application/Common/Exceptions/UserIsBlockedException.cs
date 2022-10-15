namespace iLearning.Listography.Application.Common.Exceptions;

public class UserIsBlockedException : Exception
{
    public UserIsBlockedException()
            : base()
    { }

    public UserIsBlockedException(string message)
        : base(message)
    { }

    public UserIsBlockedException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
