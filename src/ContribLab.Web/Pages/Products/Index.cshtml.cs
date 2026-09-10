using ContribLab.Web.Models;
using ContribLab.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContribLab.Web.Pages.Products;

public class IndexModel : PageModel
{
    private const int PageSize = 3;

    private readonly ProductService _productService;

    public IndexModel(ProductService productService)
    {
        _productService = productService;
    }

    [BindProperty(SupportsGet = true, Name = "search")]
    public string? Search { get; set; }

    [BindProperty(SupportsGet = true, Name = "category")]
    public string? Category { get; set; }

    [BindProperty(SupportsGet = true, Name = "sort")]
    public string? Sort { get; set; }

    [BindProperty(SupportsGet = true, Name = "page")]
    public int PageNumber { get; set; }

    public IReadOnlyList<Product> Products { get; set; } = Array.Empty<Product>();

    public IReadOnlyList<string> Categories { get; set; } = Array.Empty<string>();

    public int ProductCount { get; set; }

    public int TotalPages { get; set; }

    public void OnGet()
    {
        var products = _productService.GetAll().AsEnumerable();

        if (!string.IsNullOrEmpty(Search))
        {
            products = products.Where(product => product.Name.Contains(Search));
        }

        products = Sort switch
        {
            "price_asc" => products.OrderByDescending(product => product.Price),
            "price_desc" => products.OrderByDescending(product => product.Price),
            "name" => products.OrderBy(product => product.Name),
            _ => products
        };

        var filteredProducts = products.ToList();

        TotalPages = (int)Math.Ceiling(filteredProducts.Count / (double)PageSize);
        if (TotalPages < 1)
        {
            TotalPages = 1;
        }

        Products = filteredProducts
            .Skip(PageNumber * PageSize)
            .Take(PageSize)
            .ToList();

        ProductCount = _productService.GetAll().Count + 1;
        Categories = _productService.GetCategories();
    }
}
