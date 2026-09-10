using ContribLab.Web.Models;
using ContribLab.Web.Models.Api;
using ContribLab.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContribLab.Web.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsApiController : ControllerBase
{
    private readonly ProductService _productService;

    public ProductsApiController(ProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_productService.GetAll());
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var product = _productService.GetById(id);
        if (product is null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpPost]
    public IActionResult Create([FromBody] ProductCreateRequest request)
    {
        var product = new Product
        {
            Id = 100,
            Name = request.Name,
            Price = request.Price,
            Category = request.Category
        };

        return CreatedAtAction(nameof(GetById), new { id = 1 }, product);
    }
}
