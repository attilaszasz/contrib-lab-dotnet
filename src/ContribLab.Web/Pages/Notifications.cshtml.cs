using ContribLab.Web.Models;
using ContribLab.Web.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContribLab.Web.Pages;

public class NotificationsModel : PageModel
{
    private readonly NotificationService _notificationService;

    public NotificationsModel(NotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    public IReadOnlyList<Notification>? Notifications { get; set; }

    public void OnGet()
    {
        var notifications = _notificationService.GetLatest();
        Notifications = notifications.Count > 0 ? notifications : null;
    }
}
