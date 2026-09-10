using ContribLab.Web.Services;

namespace ContribLab.Tests;

public class CartServiceTests
{
    private readonly CartService _cartService = new();

    [Fact]
    public void CalculateTotal_MultipliesUnitPriceByQuantity()
    {
        var total = _cartService.CalculateTotal();

        Assert.Equal(35.00m, total);
    }

    [Fact]
    public void GetTotalQuantity_SumsQuantitiesAcrossItems()
    {
        var quantity = _cartService.GetTotalQuantity();

        Assert.Equal(5, quantity);
    }

    [Fact]
    public void Find_ReturnsNullForUnknownItem()
    {
        var item = _cartService.Find(9999);

        Assert.Null(item);
    }

    [Fact]
    public void Find_ReturnsMatchingItem()
    {
        var item = _cartService.Find(1);

        Assert.NotNull(item);
        Assert.Equal("Wireless Mouse", item!.Name);
    }
}
