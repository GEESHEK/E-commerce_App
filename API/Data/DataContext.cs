using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Watch> Watches { get; set; }
    public DbSet<Dial> Brand { get; set; }
    public DbSet<Calibre> Calibres { get; set; }
    public DbSet<Case> Cases { get; set; }
    public DbSet<Dial> Dials { get; set; }
    public DbSet<PowerReserve> PowerReserves { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Brand>()
            .HasIndex(b => b.Name)
            .IsUnique();
        
        modelBuilder.Entity<Calibre>()
            .HasIndex(c => c.Name)
            .IsUnique();

        modelBuilder.Entity<Dial>()
            .HasIndex(d => d.Colour)
            .IsUnique();
        
        modelBuilder.Entity<PowerReserve>()
            .HasIndex(p => p.Duration)
            .IsUnique();
    }
}