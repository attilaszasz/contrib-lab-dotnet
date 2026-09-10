using ContribLab.Web.Models;

namespace ContribLab.Web.Services;

public class CartService
{
    private readonly List<CartItem> _items = new()
    {
        new CartItem
        {
            Id = 1,
            Name = "Wireless Mouse",
            UnitPrice = 10.00m,
            Quantity = 2
        },
        new CartItem
        {
            Id = 2,
            Name = "Coffee Mug",
            UnitPrice = 5.00m,
            Quantity = 3
        }
    };

    public IReadOnlyList<CartItem> GetItems()
    {
        return _items;
    }

    public CartItem? Find(int id)
    {
        return _items.FirstOrDefault(item => item.Id == id);
    }

    public decimal CalculateTotal()
    {
        return _items.Sum(item => item.UnitPrice * item.Quantity);
    }

    public int GetTotalQuantity()
    {
        return _items.Sum(item => item.Quantity);
    }
}
