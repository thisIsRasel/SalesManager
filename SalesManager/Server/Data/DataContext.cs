using Microsoft.EntityFrameworkCore;
using SalesManager.Shared.Entities;

namespace SalesManager.Server.Data;
public partial class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Window> Windows { get; set; }

    public virtual DbSet<Element> Elements { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Order>()
            .HasMany(o => o.Windows)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder
            .Entity<Window>()
            .HasMany(w => w.SubElements)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
