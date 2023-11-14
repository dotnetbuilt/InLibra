namespace InLibra.Service.Exceptions;

public class AlreadyExistsException:Exception
{
    public int StatusCode { get; set; }

    public AlreadyExistsException(string message):base(message)
    {
        StatusCode = 403;
    }
}