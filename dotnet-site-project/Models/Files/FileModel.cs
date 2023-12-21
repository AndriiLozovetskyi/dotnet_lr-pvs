using System.ComponentModel.DataAnnotations;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace dotnet_site_project.Models;

public class FileModel
{
    public string Message { get; set; }
    [Required]
    [Display(Name = "File")]
    public IFormFile File { get; set; }
}