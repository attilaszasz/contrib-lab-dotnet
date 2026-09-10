using ContribLab.Web.Services;

namespace ContribLab.Tests;

public class ProductServiceTests
{
    private readonly ProductService _productService = new();

    [Fact]
    public void GetAll_ReturnsAllSeededProducts()
    {
        var products = _productService.GetAll();

        Assert.Equal(8, products.Count);
    }

    [Fact]
    public void GetById_ReturnsProductWithMatchingId()
    {
        var product = _productService.GetById(1);

        Assert.NotNull(product);
        Assert.Equal("Laptop", product!.Name);
        Assert.Equal(1299.99m, product.Price);
    }

    [Fact]
    public void GetById_UnknownId_ReturnsNull()
    {
        var product = _productService.GetById(9999);

        Assert.Null(product);
    }

    [Fact]
    public void GetCategories_ReturnsDistinctCategories()
    {
        var categories = _productService.GetCategories();

        Assert.Contains("Electronics", categories);
        Assert.Contains("Home Office", categories);
        Assert.Equal(categories.Count, categories.Distinct().Count());
    }
}
