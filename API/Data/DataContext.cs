using System.Diagnostics.CodeAnalysis;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

[ExcludeFromCodeCoverage]
public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Watch> Watches { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Calibre> Calibres { get; set; }
    public DbSet<CaseMaterial> CaseMaterials { get; set; }
    public DbSet<Crystal> Crystals { get; set; }
    public DbSet<Dial> Dials { get; set; }
    public DbSet<MovementType> MovementTypes { get; set; }
    public DbSet<Photo> Photos { get; set; }
    public DbSet<PowerReserve> PowerReserves { get; set; }
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<StrapBraceletMaterial> StrapBraceletMaterials { get; set; }
    public DbSet<WatchCaseMeasurements> WatchCaseMeasurements { get; set; }
    public DbSet<WatchType> WatchTypes { get; set; }
    public DbSet<WaterResistance> WaterResistances { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Brand>()
            .HasIndex(b => b.Name)
            .IsUnique();

        modelBuilder.Entity<Brand>()
            .Property(b => b.Name)
            .IsRequired();
        
        modelBuilder.Entity<Calibre>()
            .HasIndex(c => c.Name)
            .IsUnique();
        
        modelBuilder.Entity<Calibre>()
            .Property(c => c.Name)
            .IsRequired();
        
        modelBuilder.Entity<CaseMaterial>()
            .HasIndex(c => c.Material)
            .IsUnique();
        
        modelBuilder.Entity<CaseMaterial>()
            .Property(c => c.Material)
            .IsRequired();
        
        modelBuilder.Entity<Crystal>()
            .HasIndex(c => c.Material)
            .IsUnique();
        
        modelBuilder.Entity<Crystal>()
            .Property(c => c.Material)
            .IsRequired();

        modelBuilder.Entity<Dial>()
            .HasIndex(d => d.Colour)
            .IsUnique();
        
        modelBuilder.Entity<Dial>()
            .Property(d => d.Colour)
            .IsRequired();
        
        modelBuilder.Entity<MovementType>()
            .HasIndex(m => m.Type)
            .IsUnique();
        
        modelBuilder.Entity<MovementType>()
            .Property(m => m.Type)
            .IsRequired();
        
        modelBuilder.Entity<Photo>()
            .HasIndex(p => p.Url)
            .IsUnique();

        modelBuilder.Entity<Photo>()
            .Property(p => p.Url)
            .IsRequired();

        modelBuilder.Entity<Photo>()
            .Property(p => p.IsMain)
            .IsRequired();
        
        modelBuilder.Entity<Photo>()
            .HasIndex(p => p.PublicId)
            .IsUnique();

        modelBuilder.Entity<Photo>()
            .Property(p => p.PublicId)
            .IsRequired();
        
        modelBuilder.Entity<PowerReserve>()
            .HasIndex(p => p.Duration)
            .IsUnique();
        
        modelBuilder.Entity<PowerReserve>()
            .Property(p => p.Duration)
            .IsRequired();
        
        modelBuilder.Entity<Stock>()
            .Property(p => p.Quantity)
            .IsRequired();
        
        modelBuilder.Entity<StrapBraceletMaterial>()
            .HasIndex(s => s.Material)
            .IsUnique();
        
        modelBuilder.Entity<StrapBraceletMaterial>()
            .Property(s => s.Material)
            .IsRequired();
        
        modelBuilder.Entity<Watch>()
            .HasIndex(w => w.Reference)
            .IsUnique();
        
        modelBuilder.Entity<Watch>()
            .Property(w => w.Description)
            .IsRequired();
        
        modelBuilder.Entity<Watch>()
            .Property(w => w.Name)
            .IsRequired();
        
        modelBuilder.Entity<Watch>()
            .Property(w => w.Lume)
            .IsRequired();
        
        modelBuilder.Entity<Watch>()
            .Property(w => w.Price)
            .IsRequired();
        
        modelBuilder.Entity<Watch>()
            .Property(w => w.Cost)
            .IsRequired();
        
        modelBuilder.Entity<Watch>()
            .Property(w => w.Reference)
            .IsRequired();
        
        modelBuilder.Entity<Watch>()
            .Property(w => w.DateAdded)
            .IsRequired();

        modelBuilder.Entity<WatchCaseMeasurements>()
            .HasIndex(w => new {w.Diameter, w.Length, w.LugWidth, w.Thickness})
            .IsUnique();

        modelBuilder.Entity<WatchCaseMeasurements>()
            .Property(w => w.Diameter)
            .IsRequired();
        
        modelBuilder.Entity<WatchCaseMeasurements>()
            .Property(w => w.Length)
            .IsRequired();
        
        modelBuilder.Entity<WatchCaseMeasurements>()
            .Property(w => w.LugWidth)
            .IsRequired();
        
        modelBuilder.Entity<WatchCaseMeasurements>()
            .Property(w => w.Thickness)
            .IsRequired();
        
        modelBuilder.Entity<WatchType>()
            .HasIndex(w => w.Type)
            .IsUnique();
        
        modelBuilder.Entity<WatchType>()
            .Property(w => w.Type)
            .IsRequired();
        
        modelBuilder.Entity<WaterResistance>()
            .HasIndex(w => w.Resistance)
            .IsUnique();
        
        modelBuilder.Entity<WaterResistance>()
            .Property(w => w.Resistance)
            .IsRequired();
    }
}