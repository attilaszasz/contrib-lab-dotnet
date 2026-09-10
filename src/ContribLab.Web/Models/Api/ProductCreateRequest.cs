using System.ComponentModel.DataAnnotations;

namespace ContribLab.Web.Models.Api;

public class ProductCreateRequest
{
    [Required]
    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string Category { get; set; } = string.Empty;
}
