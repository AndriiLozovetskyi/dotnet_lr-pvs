using dotnet_site_project.Interfaces;

namespace dotnet_site_project.Implementations;

public class EmailMessageSender: IMessageSender
{
    public string Send()
    {
        return "Sent by Email";
    }
}