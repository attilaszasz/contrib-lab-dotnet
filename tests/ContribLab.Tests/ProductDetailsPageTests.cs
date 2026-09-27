using ContribLab.Web.Pages.Products;
using ContribLab.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContribLab.Tests;

public class ProductDetailsPageTests
{
    [Fact]
    public void OnGet_UnknownProduct_SetsNotFoundStatus()
    {
        var httpContext = new DefaultHttpContext();
        var model = CreateModel(httpContext);

        model.OnGet(999);

        Assert.Null(model.Product);
        Assert.Equal(StatusCodes.Status404NotFound, httpContext.Response.StatusCode);
    }

    [Fact]
    public void OnGet_ExistingProduct_LeavesSuccessStatus()
    {
        var httpContext = new DefaultHttpContext();
        var model = CreateModel(httpContext);

        model.OnGet(1);

        Assert.NotNull(model.Product);
        Assert.Equal(StatusCodes.Status200OK, httpContext.Response.StatusCode);
    }

    private static DetailsModel CreateModel(DefaultHttpContext httpContext)
    {
        return new DetailsModel(new ProductService())
        {
            PageContext = new PageContext { HttpContext = httpContext },
        };
    }
}
