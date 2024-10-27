using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkSamples.Models;

public class ProductType
{
    [Key]
    public int ProductTypeId { get; set; }
    public string Name { get; set; } = null!;
}
