using dotnet_site_project.Interfaces;
using dotnet_site_project.Services;

namespace dotnet_site_project.Middlewares;

public class TimeStatusMiddleware
{
    private readonly RequestDelegate _next;
    public TimeStatusMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext httpContext, TimeStatusService timeStatusService)
    {
        httpContext.Response.ContentType =
            "text/html;charset=utf-8";
        await httpContext.Response.WriteAsync($"Time: {timeStatusService.TimeStatus.GetTime()}");
    }
}
