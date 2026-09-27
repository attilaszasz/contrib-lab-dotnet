using ContribLab.Web.Pages;
using ContribLab.Web.Services;

namespace ContribLab.Tests;

public class CartPageModelTests
{
    [Fact]
    public void OnGet_TotalIncludesEachItemsQuantity()
    {
        var model = new CartModel(new CartService());

        model.OnGet(null);

        Assert.Equal(35.00m, model.Total);
    }
}
