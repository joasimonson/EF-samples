using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkSamples.Models;

public class Product
{
    [Key]
    public int ProductId { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public int TypeId { get; set; }
    public ProductType Type { get; set; } = null!;
}
