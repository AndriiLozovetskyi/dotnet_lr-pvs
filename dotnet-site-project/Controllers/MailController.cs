using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dotnet_site_project.Models;
using dotnet_site_project.services;

namespace dotnet_site_project.Controllers;

public class MailController : Controller
{
    private readonly ILogger<MailController> _logger;
    private readonly IEmailService _emailService;

    public MailController(ILogger<MailController> logger, IEmailService emailService)
    {
        _logger = logger;
        _emailService = emailService;
    }


    public IActionResult Index() // GET request
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(SendEmailViewModel model) // POST request
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        try
        {
            _emailService.Send(toEmail: model.EmailTo, messageText: model.Message);
        }
        catch (Exception e)
        {
            _logger.LogError("Error when send message:" + e);
            ModelState.AddModelError("", e.Message);
            return View(model);
        }
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}