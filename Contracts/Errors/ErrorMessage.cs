namespace Contracts.Errors;

public class ErrorMessage
{
    public string Message { get; set; }
    public ErrorMessage(string message)
    {
        Message = message;
    }
}