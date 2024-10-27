using EntityFrameworkSamples.Models;

namespace EntityFrameworkSamples;

public static class SampleData
{
    public static void Seed(AppDbContext context)
    {
        var type1 = new ProductType() { ProductTypeId = 1, Name = "Electronic" };
        var type2 = new ProductType() { ProductTypeId = 2, Name = "Wearable" };

        context.ProductTypes.AddRange(type1, type2);

        var product1 = new Product { ProductId = 1, Name = "Laptop", Price = 1200m, TypeId = type1.ProductTypeId };
        var product2 = new Product { ProductId = 2, Name = "Phone", Price = 800m, TypeId = type2.ProductTypeId };
        var product3 = new Product { ProductId = 3, Name = "Headphones", Price = 150m, TypeId = type2.ProductTypeId };

        context.Products.AddRange(product1, product2, product3);

        var order1 = new Order
        {
            OrderId = 1,
            OrderDate = DateTime.Now,
            CustomerName = "Customer 1",
            Details = new OrderDetails { Address = "123 Elm St", Status = "Pending" },
            Items =
            [
                new OrderItem { Product = product1, Quantity = 1 },
                new OrderItem { Product = product3, Quantity = 2 }
            ]
        };

        var order2 = new Order
        {
            OrderId = 2,
            OrderDate = DateTime.Now,
            CustomerName = "Customer 2",
            Details = new OrderDetails { Address = "456 Maple Ave", Status = "Delivered" },
            Items =
            [
                new OrderItem { Product = product2, Quantity = 1 }
            ]
        };

        var order3 = new Order
        {
            OrderId = 3,
            OrderDate = DateTime.Now,
            CustomerName = "Customer 3",
            Details = new OrderDetails { Address = "789 Oak Blvd", Status = "Paid" },
            Items =
            [
                new OrderItem { Product = product1, Quantity = 3 },
                new OrderItem { Product = product2, Quantity = 2 }
            ]
        };

        context.Orders.AddRange(order1, order2, order3);
        context.SaveChanges();
    }
}