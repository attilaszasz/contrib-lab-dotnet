using ContribLab.Web.Models;
using ContribLab.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContribLab.Web.Pages;

public class CartModel : PageModel
{
    private readonly CartService _cartService;

    public CartModel(CartService cartService)
    {
        _cartService = cartService;
    }

    public IReadOnlyList<CartItem> Items { get; set; } = Array.Empty<CartItem>();

    public decimal Total { get; set; }

    public int ItemCount { get; set; }

    public void OnGet(int? remove)
    {
        Items = _cartService.GetItems();
        Total = Items.Sum(item => item.UnitPrice);
        ItemCount = Items.Count;

        if (remove.HasValue)
        {
            var removedItem = _cartService.Find(remove.Value);
            TempData["CartMessage"] = removedItem is null
                ? "That item is not in your cart."
                : $"Removed {removedItem.Name} from your cart.";
        }
    }
}
