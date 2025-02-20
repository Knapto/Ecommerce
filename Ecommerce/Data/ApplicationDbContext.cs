using Ecommerce.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<ProductIngredient> ProductIngredients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        //Relationships between tables
        modelBuilder.Entity<ProductIngredient>()
            .HasKey(pi => new { pi.ProductId, pi.IngredientId });

        modelBuilder.Entity<ProductIngredient>()
            .HasOne(pi => pi.Product)
            .WithMany(p => p.ProductIngredients)
            .HasForeignKey(pi => pi.ProductId);

        modelBuilder.Entity<ProductIngredient>()
            .HasOne(pi => pi.Ingredient)
            .WithMany(i => i.ProductIngredients)
            .HasForeignKey(pi => pi.IngredientId);

        //Seed some data
        modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Hlavní Menu"},
                new Category { CategoryId = 2, Name = "Polévky" },
                new Category { CategoryId = 3, Name = "Přílohy" },
                new Category { CategoryId = 4, Name = "Nápoje" }
            );

        modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { IngredientId = 1, Name = "Vepřové Maso" },
                new Ingredient { IngredientId = 2, Name = "Kuřecí Maso" },
                new Ingredient { IngredientId = 3, Name = "Brambory" },
                new Ingredient { IngredientId = 4, Name = "Krokety" },
                new Ingredient { IngredientId = 5, Name = "Hranolky" },
                new Ingredient { IngredientId = 6, Name = "Burger Houska" },
                new Ingredient { IngredientId = 7, Name = "Rajče" },
                new Ingredient { IngredientId = 8, Name = "Celer" },
                new Ingredient { IngredientId = 9, Name = "Alkohol" },
                new Ingredient { IngredientId = 10, Name = "Malina" }
            );
        modelBuilder.Entity<Product>().HasData(

            new Product
            {
                ProductId = 1,
                Name = "Burger",
                Description = "Burger s Vepřovým mase a rajčetem",
                Price = 199m,
                Stock = 2,
                CategoryId = 1
            },

            new Product
            {
                ProductId = 2,
                Name = "Slepičí Vývar",
                Description = "Slepičí Vývar s Celerem",
                Price = 99m,
                Stock = 5,
                CategoryId = 2
            },

            new Product
            {
                ProductId = 3,
                Name = "Bramborová kaše",
                Description = "Hm kaše",
                Price = 45m,
                Stock = 0,
                CategoryId = 3
            },

            new Product
            {
                ProductId = 4,
                Name = "CockTail",
                Description = "Vodka s Rajčetem",
                Price = 999m,
                Stock = 9999,
                CategoryId = 4
            }

            );

        modelBuilder.Entity<ProductIngredient>().HasData(

            new ProductIngredient { ProductId = 1, IngredientId = 1 },
            new ProductIngredient { ProductId = 1, IngredientId = 6 },
            new ProductIngredient { ProductId = 1, IngredientId = 7 },

            new ProductIngredient { ProductId = 2, IngredientId = 2 },
            new ProductIngredient { ProductId = 2, IngredientId = 8 },

            new ProductIngredient { ProductId = 3, IngredientId = 3 },

            new ProductIngredient { ProductId = 4, IngredientId = 7 },
            new ProductIngredient { ProductId = 4, IngredientId = 9 }
            );
    }
}
