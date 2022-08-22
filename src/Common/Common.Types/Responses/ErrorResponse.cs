namespace Common.Types.Responses;

public enum ErrorType
{
    Authentication,
    Authorization,
    Validation,
    NotFound,
    BusinessLogic,
}

public class ErrorResponse
{
    public ErrorType Type { get; }
    public string Message { get; }

    public ErrorResponse(ErrorType type, string message)
    {
        Type = type;
        Message = message;
    }
}