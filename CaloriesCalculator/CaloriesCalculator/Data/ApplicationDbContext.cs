using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<AdminActions> AdminActions { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<FoodProduct> FoodProducts { get; set; }
    public DbSet<ProgressEntry> ProgressEntries { get; set; }
    public DbSet<UserProgress> UserProgress { get; set; }
    public DbSet<UserSettings> UserSettings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuring relationships
        modelBuilder.Entity<AdminActions>()
            .HasOne(a => a.Admin)
            .WithMany()
            .HasForeignKey(a => a.AdminId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<FoodProduct>()
            .HasOne(p => p.Category)
            .WithMany(c => c.FoodProducts)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ProgressEntry>()
            .HasOne(p => p.UserProgress)
            .WithMany(up => up.ProgressEntries)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserProgress>()
            .HasOne(up => up.User)
            .WithMany()
            .HasForeignKey(up => up.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserSettings>()
            .HasOne(us => us.User)
            .WithMany()
            .HasForeignKey(us => us.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

