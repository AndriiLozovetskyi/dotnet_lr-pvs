using dotnet_site_project.Interfaces;

namespace dotnet_site_project.Services;

public class TimeStatusService
{
    protected internal ITimeStatus TimeStatus { get; }

    public TimeStatusService(ITimeStatus timeStatus)
    {
        TimeStatus = timeStatus;
    }
}