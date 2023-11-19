using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;


namespace dotnet_site_project.services;

public interface IEmailService
{
    void Send(string toEmail, string messageText);
}

public class EmailService : IEmailService
{
    readonly IConfiguration configuration;

    public EmailService(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public void Send(string toEmail, string messageText)
    {
        var mailStuff = this.configuration.GetSection("EmailSender");
        var emailFrom = mailStuff["Username"];
        var password = mailStuff["Password"];

        var mailHost = mailStuff["SMTPServer"];
        var mailPort = int.Parse(mailStuff["Port"] ?? "25");

        using var emailMessage = new MimeMessage();

        emailMessage.From.Add(new MailboxAddress("sender", emailFrom));
        emailMessage.To.Add(new MailboxAddress("", toEmail));
        emailMessage.Subject = "Notification Message";
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
        {
            Text = messageText
        };

        using var client = new SmtpClient();
        client.Connect(mailHost, mailPort, SecureSocketOptions.StartTls);
        client.Authenticate(emailFrom, password);
        client.Send(emailMessage);

        client.Disconnect(true);
    }
}