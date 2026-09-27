using ContribLab.Web.Pages.Products;
using ContribLab.Web.Services;

namespace ContribLab.Tests;

public class ProductCategoryFilterTests
{
    [Fact]
    public void OnGet_FiltersProductsBySelectedCategory()
    {
        var pageModel = new IndexModel(new ProductService())
        {
            Category = "Stationery"
        };

        pageModel.OnGet();

        var product = Assert.Single(pageModel.Products);
        Assert.Equal("Notebook", product.Name);
        Assert.Equal("Stationery", product.Category);
    }
}
