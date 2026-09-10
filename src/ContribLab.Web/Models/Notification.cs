namespace ContribLab.Web.Models;

public class Notification
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Message { get; set; } = string.Empty;

    public DateTime CreatedUtc { get; set; }
}
