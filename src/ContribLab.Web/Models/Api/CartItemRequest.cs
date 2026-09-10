using System.ComponentModel.DataAnnotations;

namespace ContribLab.Web.Models.Api;

public class CartItemRequest
{
    [Range(1, int.MaxValue, ErrorMessage = "ProductId must be a positive number.")]
    public int ProductId { get; set; }

    public int Quantity { get; set; }
}
