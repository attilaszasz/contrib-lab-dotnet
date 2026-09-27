using ContribLab.Web.Pages.Products;
using ContribLab.Web.Services;

namespace ContribLab.Tests;

public class ProductsPageTests
{
    [Fact]
    public void OnGet_SearchTrimsLeadingAndTrailingWhitespace()
    {
        var model = new IndexModel(new ProductService())
        {
            Search = " Laptop "
        };

        model.OnGet();

        var product = Assert.Single(model.Products);
        Assert.Equal("Laptop", product.Name);
    }
}
