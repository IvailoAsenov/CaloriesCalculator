using CaloriesCalculator.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<UserSettings> UserSettings { get; set; }
    public DbSet<ProgressEntry> ProgressEntries { get; set; }
    public DbSet<FoodProduct> FoodProducts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<AdminAction> AdminActions { get; set; }
    public DbSet<UserProgress> UserProgress { get; set; }


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<FoodProduct>()
            .HasOne(fp => fp.Category)
            .WithMany(c => c.FoodProducts)
            .HasForeignKey(fp => fp.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<UserSettings>()
            .HasOne(us => us.User)
            .WithMany()
            .HasForeignKey(us => us.UserId)
            .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<ProgressEntry>()
            .HasOne(pe => pe.User)
            .WithMany()
            .HasForeignKey(pe => pe.UserId)
            .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<AdminAction>()
            .HasOne(aa => aa.Admin)
            .WithMany()
            .HasForeignKey(aa => aa.AdminId)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserProgress>()
            .HasOne(up => up.User)
            .WithMany()
            .HasForeignKey(up => up.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);

        // Добавяне на уникален индекс за комбинацията от UserId и Date
        modelBuilder.Entity<UserProgress>()
            .HasIndex(up => new { up.UserId, up.Date })
            .IsUnique();
    }

}


