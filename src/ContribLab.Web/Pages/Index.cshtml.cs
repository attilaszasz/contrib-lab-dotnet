using ContribLab.Web.Models;
using ContribLab.Web.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContribLab.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ProductService _productService;

    public IndexModel(ProductService productService)
    {
        _productService = productService;
    }

    public IReadOnlyList<Product> FeaturedProducts { get; set; } = Array.Empty<Product>();

    public void OnGet()
    {
        FeaturedProducts = _productService.GetAll().Take(3).ToList();
    }
}
