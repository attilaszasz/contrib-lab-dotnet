using ContribLab.Web.Models;

namespace ContribLab.Web.Services;

public class NotificationService
{
    private readonly List<Notification> _notifications = new();

    public IReadOnlyList<Notification> GetLatest()
    {
        return _notifications;
    }
}
