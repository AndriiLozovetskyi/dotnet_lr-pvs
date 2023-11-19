using dotnet_site_project.Interfaces;
using dotnet_site_project.Services;

namespace dotnet_site_project.Middlewares;

public class CounterMiddleware
{
    private readonly RequestDelegate _next;
    private int i = 0; // счетчик запросов
    public CounterMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext httpContext,
        ICounter counter, CounterService counterService)
    {
        i++;
        httpContext.Response.ContentType =
            "text/html;charset=utf-8";
        await httpContext.Response.WriteAsync($"Запрос {i}; Counter: {counter.Value}; Service: {counterService.Counter.Value}");
    }
}
