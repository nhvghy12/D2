using D2.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace D2.Data;
public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Categories
        builder.Entity<Category>(e => e.ToTable("Categories"));
        // builder.Entity<Category>().HasKey(e => e.Id);
        // builder.Entity<Category>().Property(e => e.Name).IsRequired();
        builder.Entity<Category>()
        .HasMany(category => category.Products)
        .WithOne(product => product.Category)
        .HasForeignKey(product => product.CategoryId)
        .IsRequired();

        var data = new List<Category>
        {
            new Category{Id=1, Name="Foot"},
            new Category{Id=2, Name="Cosmetic"},
            new Category{Id=3, Name="Drinks"},
            new Category{Id=4, Name="Fashion"},
            new Category{Id=5, Name="High tech"},

        };
        builder.Entity<Category>().HasData(data);
        
        // Product
        builder.Entity<Product>(e => e.ToTable("Products"));

        // builder.Entity<Product>()
        // .HasOne(p => p.Category)
        // .WithMany(c => c.Products)
        // .HasForeignKey(p => p.CategoryId)
        // .IsRequired();

    }
    public virtual DbSet<Student>? Students { get; set; }
    // public virtual DbSet<Category>? Categories { get; set; }
    // public virtual DbSet<Product>? Products { get; set; }

    
}