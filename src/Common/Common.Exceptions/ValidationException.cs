namespace Common.Exceptions;

public class ValidationError
{
    public string PropertyName { get; }
    public string ErrorMessage { get; }

    public ValidationError(string propertyName, string errorMessage)
    {
        PropertyName = propertyName;
        ErrorMessage = errorMessage;
    }
}

public class ValidationException : ApplicationException
{
    public ICollection<ValidationError> Errors { get; }

    public ValidationException(ICollection<ValidationError> errors)
    {
        Errors = errors;
    }
}