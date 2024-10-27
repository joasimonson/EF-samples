using EntityFrameworkSamples.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkSamples;

public class AppDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderDetails> OrderDetails { get; set; } = null!;
    public DbSet<OrderItem> OrderItems { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<ProductType> ProductTypes { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseInMemoryDatabase("TestDB");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Details)
            .WithOne()
            .HasForeignKey<OrderDetails>(d => d.OrderId);

        modelBuilder.Entity<Order>()
            .ToTable("Orders");

        modelBuilder.Entity<OrderDetails>()
            .ToTable("Orders");

        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Product)
            .WithMany()
            .HasForeignKey(oi => oi.ProductId);

        modelBuilder.Entity<Order>()
            .HasMany(o => o.Items)
            .WithOne()
            .HasForeignKey(oi => oi.ProductId);

        modelBuilder.Entity<Product>()
            .HasOne(o => o.Type)
            .WithOne()
            .HasForeignKey<ProductType>(oi => oi.ProductTypeId);
    }
}
