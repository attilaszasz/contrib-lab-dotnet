using ContribLab.Web.Models;
using ContribLab.Web.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContribLab.Web.Pages.Products;

public class DetailsModel : PageModel
{
    private readonly ProductService _productService;

    public DetailsModel(ProductService productService)
    {
        _productService = productService;
    }

    public Product? Product { get; set; }

    public void OnGet(int id)
    {
        Product = _productService.GetById(id);
    }
}
