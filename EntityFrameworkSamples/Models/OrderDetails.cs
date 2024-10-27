using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkSamples.Models;

public class OrderDetails
{
    [Key]
    public int OrderId { get; set; }
    public string Status { get; set; } = null!;
    public string Address { get; set; } = null!;
}