using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkSamples.Models;

public class Order
{
    [Key]
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public string CustomerName { get; set; } = null!;
    public OrderDetails Details { get; set; } = null!;
    public List<OrderItem> Items { get; set; } = null!;
}