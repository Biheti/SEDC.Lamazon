using Microsoft.EntityFrameworkCore;
using SEDC.Lamazon.Domain.Entities;

namespace SEDC.Lamazon.DataAccess.Context;

public class LamazonDbContext : DbContext
{
    public LamazonDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
}
