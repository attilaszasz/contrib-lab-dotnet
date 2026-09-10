using System.ComponentModel.DataAnnotations;

namespace ContribLab.Web.Models;

public class ContactFormModel
{
    [Required(ErrorMessage = "Please enter your name.")]
    [Display(Name = "Your name")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter your email address.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    [Display(Name = "Email address")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter a message.")]
    [StringLength(1000, ErrorMessage = "The message must be 1000 characters or fewer.")]
    [Display(Name = "Message")]
    public string Message { get; set; } = string.Empty;
}
