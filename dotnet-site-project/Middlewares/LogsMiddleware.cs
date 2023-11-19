
namespace dotnet_site_project.Middlewares;

public class LogsMiddleware
{
    private readonly RequestDelegate _next;

    public LogsMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var request = context.Request;
        var ipAddress = context.Connection.RemoteIpAddress;
        var requestTime = DateTime.Now;
        var logMessage = $"{request.Scheme}://{request.Host}{request.Path}{request.QueryString} [:] " +
                         $"Time:{requestTime}, " +
                         $"IP:{ipAddress}";   
        context.RequestServices.GetRequiredService<ILogger<Program>>().LogInformation(logMessage);
        await _next(context);
        
    }
}