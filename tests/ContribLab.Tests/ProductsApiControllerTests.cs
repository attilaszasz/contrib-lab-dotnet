using ContribLab.Web.Controllers;
using ContribLab.Web.Models;
using ContribLab.Web.Models.Api;
using ContribLab.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContribLab.Tests;

public class ProductsApiControllerTests
{
    [Fact]
    public void Create_UsesCreatedProductIdForLocation()
    {
        var controller = new ProductsApiController(new ProductService());
        var result = Assert.IsType<CreatedAtActionResult>(controller.Create(new ProductCreateRequest
        {
            Name = "Test Widget",
            Price = 9.99m,
            Category = "Demo"
        }));
        var product = Assert.IsType<Product>(result.Value);

        Assert.Equal(product.Id, Assert.IsType<int>(result.RouteValues!["id"]));
    }
}
