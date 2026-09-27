using ContribLab.Web.Pages.Products;
using ContribLab.Web.Services;

namespace ContribLab.Tests;

public class ProductsIndexModelTests
{
    [Fact]
    public void OnGet_PriceAscendingSort_ShowsCheapestProductsFirst()
    {
        var model = new IndexModel(new ProductService()) { Sort = "price_asc" };

        model.OnGet();

        Assert.Equal(
            new[] { 4.99m, 12.50m, 19.90m },
            model.Products.Select(product => product.Price));
    }
}
