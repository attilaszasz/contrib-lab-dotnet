using ContribLab.Web.Services;

namespace ContribLab.Tests;

public class NotificationServiceTests
{
    [Fact]
    public void GetLatest_ReturnsEmptyCollectionWhenThereAreNoNotifications()
    {
        var notificationService = new NotificationService();

        var notifications = notificationService.GetLatest();

        Assert.NotNull(notifications);
        Assert.Empty(notifications);
    }
}
