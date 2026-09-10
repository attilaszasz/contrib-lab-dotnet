using ContribLab.Web.Models;

namespace ContribLab.Web.Services;

public class ProductService
{
    private readonly List<Product> _products = new()
    {
        new Product
        {
            Id = 1,
            Name = "Laptop",
            Description = "A lightweight 14-inch laptop for everyday work.",
            Price = 1299.99m,
            Category = "Electronics"
        },
        new Product
        {
            Id = 2,
            Name = "Wireless Mouse",
            Description = "A quiet wireless mouse with a long battery life.",
            Price = 24.50m,
            Category = "Electronics"
        },
        new Product
        {
            Id = 3,
            Name = "Mechanical Keyboard",
            Description = "A compact mechanical keyboard with tactile switches.",
            Price = 89.90m,
            Category = "Electronics"
        },
        new Product
        {
            Id = 4,
            Name = "Desk Lamp",
            Description = "An adjustable LED desk lamp with three brightness levels.",
            Price = 39.95m,
            Category = "Home Office"
        },
        new Product
        {
            Id = 5,
            Name = "Notebook",
            Description = "A dotted A5 notebook with 160 pages.",
            Price = 4.99m,
            Category = "Stationery"
        },
        new Product
        {
            Id = 6,
            Name = "Backpack",
            Description = "A water-resistant backpack with a padded laptop sleeve.",
            Price = 59.00m,
            Category = "Accessories"
        },
        new Product
        {
            Id = 7,
            Name = "Water Bottle",
            Description = "An insulated stainless steel water bottle.",
            Price = 19.90m,
            Category = "Accessories"
        },
        new Product
        {
            Id = 8,
            Name = "Coffee Mug",
            Description = "A ceramic mug that keeps your coffee warm.",
            Price = 12.50m,
            Category = "Home Office"
        }
    };

    public IReadOnlyList<Product> GetAll()
    {
        return _products;
    }

    public Product? GetById(int id)
    {
        return _products.FirstOrDefault(product => product.Id == id);
    }

    public IReadOnlyList<string> GetCategories()
    {
        return _products
            .Select(product => product.Category)
            .Distinct()
            .OrderBy(category => category)
            .ToList();
    }
}
