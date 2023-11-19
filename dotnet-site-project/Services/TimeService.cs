namespace dotnet_site_project.Services;

public class TimeService
{
    public string GetTime()
    {
        return System.DateTime.Now.ToString("hh:mm:ss");
    }
}