using InLibra.Service.Exceptions;
using InLibra.WebApi.Models;

namespace InLibra.WebApi.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next,
        ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (AlreadyExistsException exception)
        {
            context.Response.StatusCode = exception.StatusCode;
        
            await context.Response.WriteAsJsonAsync(new Response
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            });
        }
        catch (NotFoundException exception)
        {
            context.Response.StatusCode = exception.StatusCode;
        
            await context.Response.WriteAsJsonAsync(new Response
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            });
        }
        catch (CustomException exception)
        {
            context.Response.StatusCode = exception.StatusCode;
        
            await context.Response.WriteAsJsonAsync(new Response
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            });
        }
        catch (Exception exception)
        {
            context.Response.StatusCode = 500;
            _logger.LogError(message:exception.ToString());
            await context.Response.WriteAsJsonAsync(new Response
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            });
        }
    }
}