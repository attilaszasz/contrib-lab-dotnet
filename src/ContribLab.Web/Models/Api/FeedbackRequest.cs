using System.ComponentModel.DataAnnotations;

namespace ContribLab.Web.Models.Api;

public class FeedbackRequest
{
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    public string Message { get; set; } = string.Empty;

    [Range(1, 5)]
    public int Rating { get; set; } = 5;
}
