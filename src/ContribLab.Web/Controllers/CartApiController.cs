using ContribLab.Web.Models.Api;
using Microsoft.AspNetCore.Mvc;

namespace ContribLab.Web.Controllers;

[ApiController]
[Route("api/cart")]
public class CartApiController : ControllerBase
{
    [HttpPost("items")]
    public IActionResult AddItem([FromBody] CartItemRequest request)
    {
        var unitPrice = 10.00m;
        var lineTotal = unitPrice * request.Quantity;

        return Ok(new
        {
            request.ProductId,
            request.Quantity,
            LineTotal = lineTotal
        });
    }
}
