using System.ComponentModel.DataAnnotations;

namespace dotnet_site_project.Models
{
    public class SendEmailViewModel
    {
        [DataType(DataType.EmailAddress), Display(Name = "Email To"), Required]
        public string EmailTo { get; set; }

        [DataType(DataType.Text), Display(Name = "Message"), Required]
        public string Message { get; set; }

        public SendEmailViewModel() // using for basic constructor
        {
            EmailTo = string.Empty;
            Message = string.Empty;
        }
    }
}