using dotnet_site_project.Interfaces;

namespace dotnet_site_project.Services;

public class CounterService
{
    protected internal ICounter Counter { get; }

    public CounterService(ICounter counter)
    {
        Counter = counter;
    }
}