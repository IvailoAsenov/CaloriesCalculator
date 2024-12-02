using CaloriesCalculator.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<FoodProduct> FoodProducts { get; set; }
    public DbSet<Meal> Meals { get; set; }
    public DbSet<MealFoodProduct> MealFoodProducts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<UserSettings> UserSettings { get; set; } 

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<MealFoodProduct>()
            .HasKey(mf => new { mf.MealId, mf.FoodProductId });

        modelBuilder.Entity<MealFoodProduct>()
            .HasOne(mf => mf.Meal)
            .WithMany(m => m.MealFoodProducts)
            .HasForeignKey(mf => mf.MealId);

        modelBuilder.Entity<MealFoodProduct>()
            .HasOne(mf => mf.FoodProduct)
            .WithMany(f => f.MealFoodProducts)
            .HasForeignKey(mf => mf.FoodProductId);

       
        modelBuilder.Entity<FoodProduct>()
            .Property(f => f.Protein)
            .HasPrecision(18, 4);

        modelBuilder.Entity<FoodProduct>()
            .Property(f => f.Carbs)
            .HasPrecision(18, 4);

        modelBuilder.Entity<FoodProduct>()
            .Property(f => f.Fat)
            .HasPrecision(18, 4);
    }
}
