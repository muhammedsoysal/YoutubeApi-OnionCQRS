using System.Reflection;
using Microsoft.EntityFrameworkCore;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext() { }

    public AppDbContext(DbContextOptions options):base(options)
    {
    }

    public List<Brand> Brands { get; set; }
    public List<Category> Categories { get; set; }
    public List<Detail>Details { get; set; }
    public List<Product>Products{ get; set; }
    public List<ProductCategory>ProductCategories{ get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}