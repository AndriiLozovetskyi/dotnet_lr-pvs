using dotnet_site_project.Interfaces;

namespace dotnet_site_project.Implementations;

using System;

public class GetTimeStatus : ITimeStatus
{
    public string GetTime()
    {
        return DateTime.Now.ToString("hh:mm:ss");
    }
}