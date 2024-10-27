using EntityFrameworkSamples;
using Microsoft.EntityFrameworkCore;

using var context = new AppDbContext();

SampleData.Seed(context);

var orders = context.Orders
    .Include(o => o.Details)
    .Include(o => o.Items)
    .ThenInclude(i => i.Product)
    .ToList();

foreach (var order in orders)
{
    Console.WriteLine($"Order {order.OrderId}, Date: {order.OrderDate}, Shipping Address: {order.Details.Address}");
    foreach (var item in order.Items)
    {
        Console.WriteLine($"   Product: {item.Product.Name}, Quantity: {item.Quantity}, Price: {item.Product.Price}");
    }
}